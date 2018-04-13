using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RDPRunner
{
   public partial class MainForm : Form
   {
      private enum HandlerStatus
      {
         WaitPlugIn,
         WaitPlugOut,
         Exit
      }

      private const string RDP_RUNNER_PROCESS_NAME = "RDPRunner";
      private const string RUN_FILE_PATH = "mstsc"; // depand on PassGenerator.FormPassGenerator
      private const string MSTSC_COMMAND = RUN_FILE_PATH;
      private const string CMDKEY_COMMAND = "cmdkey";
      private const string REMOTE_DESKTOP = "192.168.1.2";

      private const int WAIT_BEFORE_CLEAR_PASSWORD_MILLISECONDS = 2 * 1000;
      private const int WAIT_PLUG_IN_MILLISECONDS = 50;
      private const int WAIT_PLUG_OUT_MILLISECONDS = 50;

      private const int NOT_VALID_ID = -1;

      private List<int> listProcessRuns = new List<int>();
      private HandlerStatus handlerStatus = HandlerStatus.WaitPlugIn;

      private int ProcessPID { get; set; }
      private string FilePathFound { get; set; }
      private string UserName { get; set; }
      private string Password { get; set; }

      public MainForm()
      {
         InitializeComponent();

         FormClosing += ExitHandler;
         Shown += Show;
      }

      #region Setup
      private void ExitHandler(object sender, FormClosingEventArgs e)
      {
         handlerStatus = HandlerStatus.Exit;
      }

      private void Show(object sender, EventArgs e)
      {
         // just close if process with current name already run
         if (Process.GetProcessesByName(RDP_RUNNER_PROCESS_NAME).Count() > 1) {
            Close();
            return;
         }

         Hide();
         ShowInTaskbar = false;

         RunHandler();
      }

      private void RunHandler()
      {
         while (handlerStatus != HandlerStatus.Exit) {
            PlugInHandler();
            PlugOutHandler();
         }
      }
      #endregion

      #region Plug In Handler
      private void PlugInHandler()
      {
         PreparationForPlugIn();

         while (handlerStatus == HandlerStatus.WaitPlugIn) {
            try {
               foreach (var driverName in GetRemoteDriverNames()) {
                  var filePath = driverName + RUN_FILE_PATH;
                  if (File.Exists(filePath)) {
                     // decode file
                     using (var fileStream = File.OpenRead(filePath)) {
                        using (var br = new BinaryReader(fileStream, Encoding.Default, false)) {
                           // read userName
                           var usernameLength = br.ReadInt32();
                           var userName = new StringBuilder();
                           for (var i = 0; i < usernameLength; i++) {
                              br.ReadBytes(br.ReadInt32());

                              userName.Append(br.ReadChar());
                           }
                           UserName = userName.ToString();

                           // read password
                           var passLength = br.ReadInt32();
                           var pass = new StringBuilder();
                           for (var i = 0; i < passLength; i++) {
                              br.ReadBytes(br.ReadInt32());

                              pass.Append(br.ReadChar());
                           }
                           Password = pass.ToString();
                        }
                     }

                     if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password)) {
                        continue;
                     }

                     FilePathFound = filePath;
                     ProcessPID = GetRunProcessId();
                     handlerStatus = HandlerStatus.WaitPlugOut;
                     break;
                  }
               }
            }
            catch { }
            Thread.Sleep(WAIT_PLUG_IN_MILLISECONDS);
         }
      }

      private void PreparationForPlugIn()
      {
         ProcessPID = NOT_VALID_ID;
         FilePathFound = "";
         UserName = "";
         Password = "";
      }

      private static IEnumerable<string> GetRemoteDriverNames()
      {
         return DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).Select(d => d.Name);
      }

      /// <summary>
      /// To get correct run PID for mstsc process we proceeded the next steps:
      /// 1. Get all processes by name and save them.
      /// 2. Run process
      /// 3. Get all processes by name and looking for the new one.
      /// 4. Return the found PID, otherwise return NOT_VALID_ID
      /// </summary>
      private int GetRunProcessId()
      {
         listProcessRuns.Clear();

         foreach (var item in Process.GetProcessesByName(MSTSC_COMMAND)) {
            listProcessRuns.Add(item.Id);
         }

         RunProcess();

         foreach (var item in Process.GetProcessesByName(MSTSC_COMMAND)) {
            if (!listProcessRuns.Contains(item.Id)) {
               return item.Id;
            }
         }

         return NOT_VALID_ID;
      }

      private void RunProcess()
      {
         // Save credential
         Process.Start(CMDKEY_COMMAND, $"/generic:TERMSRV/{REMOTE_DESKTOP} /user:{UserName} /pass:{Password}");

         // run rdp
         Process.Start(MSTSC_COMMAND, $"/v:{REMOTE_DESKTOP}");
         Thread.Sleep(WAIT_BEFORE_CLEAR_PASSWORD_MILLISECONDS);

         // Delete credential
         Process.Start(CMDKEY_COMMAND, $"/delete:TERMSRV/{REMOTE_DESKTOP}");
      }
      #endregion

      #region Plug Out Handler
      private void PlugOutHandler()
      {
         while (handlerStatus == HandlerStatus.WaitPlugOut) {
            try {
               if (!File.Exists(FilePathFound)) {
                  QuitProcess(ProcessPID);
                  handlerStatus = HandlerStatus.WaitPlugIn;
               }
            }
            catch { }
            Thread.Sleep(WAIT_PLUG_OUT_MILLISECONDS);
         }
      }

      private void QuitProcess(int id)
      {
         if (id == NOT_VALID_ID) {
            return;
         }

         var mstscProcesses = Process.GetProcessesByName(MSTSC_COMMAND).Where(p => p.Id == id);
         if (mstscProcesses.Any()) {
            mstscProcesses.First().Kill();
         }
      }
      #endregion
   }
}