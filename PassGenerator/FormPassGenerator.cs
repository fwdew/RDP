using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PassGenerator
{
   public partial class FormPassGenerator : Form
   {
      private const string SETUP_FILE_PATH = "users.xml";
      private const string RUN_FILE_PATH = "mstsc"; // depand on RDPRunner.MainForm

      #region Properties
      private string Password => textBoxPassword.Text;

      private string FilePath { get; set; }
      #endregion

      #region Constructors
      public FormPassGenerator()
      {
         InitializeComponent();
         Setup();
      }

      private void Setup()
      {
         textBoxPassword.Text = "";

         UpdateUserNames();
         UpdateDriverNames();
      }
      #endregion

      #region Controls Event
      private void buttonRefresh_Click(object sender, EventArgs e)
      {
         UpdateUserNames();
         UpdateDriverNames();
      }

      private void buttonReset_Click(object sender, EventArgs e)
      {
         Setup();
      }

      private void buttonWriteToFile_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(textBoxPassword.Text)) {
            MessageBox.Show("Can't write empty password to the file.");
            return;
         }

         if (WritePasswordToTheFile()) {
            MessageBox.Show($"File {FilePath} has been successufully created.");
         }
      }
      #endregion

      private bool WritePasswordToTheFile()
      {
         if (string.IsNullOrEmpty(comboBoxUserName.SelectedItem.ToString())) {
            MessageBox.Show("Select user name from the list.");
            return false;
         }

         if (comboBoxDriverNames.SelectedIndex == -1) {
            MessageBox.Show("Select driver name from the list.");
            return false;
         }

         var userName = comboBoxUserName.SelectedItem.ToString();
         var driverName = comboBoxDriverNames.SelectedItem.ToString();

         if (!Directory.Exists(driverName)) {
            MessageBox.Show("Can't generate file to current drive.");
            return false;
         }

         try {
            var randomByteArray = new byte[1000 * 1000];
            var random = new Random();
            random.NextBytes(randomByteArray);

            var index = 0;
            FilePath = driverName + RUN_FILE_PATH;
            using (var f = File.Create(FilePath)) {
               using (var bw = new BinaryWriter(f, Encoding.Default, false)) {
                  // write username
                  bw.Write(userName.Length);
                  for (var i = 0; i < userName.Length; i++) {
                     var randomShift = randomByteArray[index++] / 10;
                     bw.Write(randomShift);
                     bw.Write(randomByteArray, index, randomShift);
                     bw.Write(userName[i]);
                     index += randomShift;
                  }
                  // write password
                  bw.Write(Password.Length);
                  for (var i = 0; i < Password.Length; i++) {
                     var randomShift = randomByteArray[index++] / 10;
                     bw.Write(randomShift);
                     bw.Write(randomByteArray, index, randomShift);
                     bw.Write(Password[i]);
                     index += randomShift;
                  }
                  bw.Write(randomByteArray, index, index);
               }
            }
         }
         catch {
            MessageBox.Show("Can't write file to the drive. Please, restart your program and try again. Otherwise, contact administator: +38(032)2452222.");
            return false;
         }

         return true;
      }

      private void UpdateUserNames()
      {
         if (!File.Exists(SETUP_FILE_PATH)) {
            return;
         }

         try {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(SETUP_FILE_PATH);

            comboBoxUserName.Items.Clear();

            // read data from each node "user" and populate comboBox
            foreach (XmlNode node in xmlDoc.SelectSingleNode(@"/main/users").ChildNodes) {
               string program_name = node.InnerText;
               comboBoxUserName.Items.Add(program_name);
            }
         }
         catch (Exception ex) {
            MessageBox.Show(ex.ToString());
         }
      }

      private void UpdateDriverNames()
      {
         comboBoxDriverNames.Items.Clear();
         comboBoxDriverNames.Items.AddRange(DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).ToArray());
      }
   }
}