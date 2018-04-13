namespace Install
{
   partial class FormInstall
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
         this.buttonInstall = new System.Windows.Forms.Button();
         this.labelInstall = new System.Windows.Forms.Label();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.checkBoxListener = new System.Windows.Forms.CheckBox();
         this.checkBoxGenerator = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // buttonInstall
         // 
         this.buttonInstall.Location = new System.Drawing.Point(93, 60);
         this.buttonInstall.Name = "buttonInstall";
         this.buttonInstall.Size = new System.Drawing.Size(51, 40);
         this.buttonInstall.TabIndex = 2;
         this.buttonInstall.Text = "Install";
         this.buttonInstall.UseVisualStyleBackColor = true;
         this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
         // 
         // labelInstall
         // 
         this.labelInstall.Location = new System.Drawing.Point(12, 9);
         this.labelInstall.Name = "labelInstall";
         this.labelInstall.Size = new System.Drawing.Size(190, 48);
         this.labelInstall.TabIndex = 3;
         this.labelInstall.Text = "Choose what do you want to install:\r\n1. RDP Listener \r\n2. Password Generator";
         // 
         // buttonCancel
         // 
         this.buttonCancel.Location = new System.Drawing.Point(150, 60);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(52, 40);
         this.buttonCancel.TabIndex = 4;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
         // 
         // checkBoxListener
         // 
         this.checkBoxListener.AutoSize = true;
         this.checkBoxListener.Location = new System.Drawing.Point(12, 60);
         this.checkBoxListener.Name = "checkBoxListener";
         this.checkBoxListener.Size = new System.Drawing.Size(63, 17);
         this.checkBoxListener.TabIndex = 5;
         this.checkBoxListener.Text = "Listener";
         this.checkBoxListener.UseVisualStyleBackColor = true;
         // 
         // checkBoxGenerator
         // 
         this.checkBoxGenerator.AutoSize = true;
         this.checkBoxGenerator.Location = new System.Drawing.Point(12, 83);
         this.checkBoxGenerator.Name = "checkBoxGenerator";
         this.checkBoxGenerator.Size = new System.Drawing.Size(73, 17);
         this.checkBoxGenerator.TabIndex = 6;
         this.checkBoxGenerator.Text = "Generator";
         this.checkBoxGenerator.UseVisualStyleBackColor = true;
         // 
         // FormInstall
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(214, 111);
         this.Controls.Add(this.checkBoxGenerator);
         this.Controls.Add(this.checkBoxListener);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.labelInstall);
         this.Controls.Add(this.buttonInstall);
         this.Name = "FormInstall";
         this.Text = "RDP Install";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button buttonInstall;
      private System.Windows.Forms.Label labelInstall;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.CheckBox checkBoxListener;
      private System.Windows.Forms.CheckBox checkBoxGenerator;
   }
}