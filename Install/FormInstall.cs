using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Install
{
   public partial class FormInstall : Form
   {
      private const string SETUP_FOLDER = "Setup";
      private const string LISTENER_FILE = "RDPRunnerSetup.msi";
      private const string GENERATION_FILE = "GeneratorSetup.msi";

      private string ListenerPath => $"{SETUP_FOLDER}/{LISTENER_FILE}";
      private string GeneratorPath => $"{SETUP_FOLDER}/{GENERATION_FILE}";

      public FormInstall()
      {
         InitializeComponent();

         checkBoxListener.Checked = true;
      }

      private void buttonInstall_Click(object sender, EventArgs e)
      {
         var needToClose = false;

         if (checkBoxListener.Checked && Directory.Exists(SETUP_FOLDER) && File.Exists(ListenerPath)) {
            var prInfo = new ProcessStartInfo(LISTENER_FILE) {
               WorkingDirectory = Path.GetDirectoryName(Path.GetFullPath(ListenerPath))
            };
            Process.Start(prInfo);
            needToClose = true;
         }

         if (checkBoxGenerator.Checked && Directory.Exists(SETUP_FOLDER) && File.Exists(GeneratorPath)) {
            var prInfo = new ProcessStartInfo(GENERATION_FILE) {
               WorkingDirectory = Path.GetDirectoryName(Path.GetFullPath(GeneratorPath))
            };
            Process.Start(prInfo);
            needToClose = true;
         }

         if (needToClose) {
            Close();
         }
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}