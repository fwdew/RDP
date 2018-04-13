namespace PassGenerator
{
   partial class FormPassGenerator
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.comboBoxDriverNames = new System.Windows.Forms.ComboBox();
         this.textBoxPassword = new System.Windows.Forms.TextBox();
         this.comboBoxUserName = new System.Windows.Forms.ComboBox();
         this.buttonRefresh = new System.Windows.Forms.Button();
         this.buttonWriteToFile = new System.Windows.Forms.Button();
         this.buttonReset = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // comboBoxDriverNames
         // 
         this.comboBoxDriverNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxDriverNames.FormattingEnabled = true;
         this.comboBoxDriverNames.Location = new System.Drawing.Point(118, 40);
         this.comboBoxDriverNames.Name = "comboBoxDriverNames";
         this.comboBoxDriverNames.Size = new System.Drawing.Size(94, 21);
         this.comboBoxDriverNames.TabIndex = 10;
         // 
         // textBoxPassword
         // 
         this.textBoxPassword.Location = new System.Drawing.Point(12, 14);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.Size = new System.Drawing.Size(259, 20);
         this.textBoxPassword.TabIndex = 12;
         // 
         // comboBoxUserName
         // 
         this.comboBoxUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxUserName.FormattingEnabled = true;
         this.comboBoxUserName.Location = new System.Drawing.Point(12, 40);
         this.comboBoxUserName.Name = "comboBoxUserName";
         this.comboBoxUserName.Size = new System.Drawing.Size(100, 21);
         this.comboBoxUserName.TabIndex = 13;
         // 
         // buttonRefresh
         // 
         this.buttonRefresh.Location = new System.Drawing.Point(218, 40);
         this.buttonRefresh.Name = "buttonRefresh";
         this.buttonRefresh.Size = new System.Drawing.Size(52, 21);
         this.buttonRefresh.TabIndex = 14;
         this.buttonRefresh.Text = "Refresh";
         this.buttonRefresh.UseVisualStyleBackColor = true;
         this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
         // 
         // buttonWriteToFile
         // 
         this.buttonWriteToFile.Location = new System.Drawing.Point(12, 67);
         this.buttonWriteToFile.Name = "buttonWriteToFile";
         this.buttonWriteToFile.Size = new System.Drawing.Size(200, 23);
         this.buttonWriteToFile.TabIndex = 15;
         this.buttonWriteToFile.Text = "Записати на диск";
         this.buttonWriteToFile.UseVisualStyleBackColor = true;
         this.buttonWriteToFile.Click += new System.EventHandler(this.buttonWriteToFile_Click);
         // 
         // buttonReset
         // 
         this.buttonReset.Location = new System.Drawing.Point(218, 67);
         this.buttonReset.Name = "buttonReset";
         this.buttonReset.Size = new System.Drawing.Size(52, 23);
         this.buttonReset.TabIndex = 16;
         this.buttonReset.Text = "Reset";
         this.buttonReset.UseVisualStyleBackColor = true;
         this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
         // 
         // FormPassGenerator
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 103);
         this.Controls.Add(this.buttonReset);
         this.Controls.Add(this.buttonWriteToFile);
         this.Controls.Add(this.buttonRefresh);
         this.Controls.Add(this.comboBoxUserName);
         this.Controls.Add(this.textBoxPassword);
         this.Controls.Add(this.comboBoxDriverNames);
         this.Name = "FormPassGenerator";
         this.Text = "Password Generator";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.ComboBox comboBoxDriverNames;
      private System.Windows.Forms.TextBox textBoxPassword;
      private System.Windows.Forms.ComboBox comboBoxUserName;
      private System.Windows.Forms.Button buttonRefresh;
      private System.Windows.Forms.Button buttonWriteToFile;
      private System.Windows.Forms.Button buttonReset;
   }
}