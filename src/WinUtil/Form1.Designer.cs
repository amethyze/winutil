namespace WinUtil
{
    partial class Form1
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TitleForm1 = new System.Windows.Forms.Label();
            this.stopEx = new System.Windows.Forms.Button();
            this.programKill = new System.Windows.Forms.Button();
            this.taskmgr = new System.Windows.Forms.Button();
            this.startEx = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.deleterDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileDel = new System.Windows.Forms.Button();
            this.superFileShortcut = new System.Windows.Forms.OpenFileDialog();
            this.superShortcutSave = new System.Windows.Forms.SaveFileDialog();
            this.superFolderShortcut = new System.Windows.Forms.FolderBrowserDialog();
            this.faq = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleForm1
            // 
            this.TitleForm1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.TitleForm1.ForeColor = System.Drawing.Color.White;
            this.TitleForm1.Location = new System.Drawing.Point(12, 9);
            this.TitleForm1.Name = "TitleForm1";
            this.TitleForm1.Size = new System.Drawing.Size(776, 57);
            this.TitleForm1.TabIndex = 0;
            this.TitleForm1.Text = "WinUtil - Tools for Windows";
            this.TitleForm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleForm1.Click += new System.EventHandler(this.TitleForm1_Click);
            // 
            // stopEx
            // 
            this.stopEx.BackColor = System.Drawing.Color.White;
            this.stopEx.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stopEx.Location = new System.Drawing.Point(12, 97);
            this.stopEx.Name = "stopEx";
            this.stopEx.Size = new System.Drawing.Size(133, 22);
            this.stopEx.TabIndex = 1;
            this.stopEx.Text = "Stop Explorer";
            this.stopEx.UseVisualStyleBackColor = false;
            this.stopEx.Click += new System.EventHandler(this.button1_Click);
            // 
            // programKill
            // 
            this.programKill.BackColor = System.Drawing.Color.White;
            this.programKill.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.programKill.Location = new System.Drawing.Point(151, 69);
            this.programKill.Name = "programKill";
            this.programKill.Size = new System.Drawing.Size(80, 50);
            this.programKill.TabIndex = 2;
            this.programKill.Text = "Program Killer";
            this.programKill.UseVisualStyleBackColor = false;
            this.programKill.Click += new System.EventHandler(this.button2_Click);
            // 
            // taskmgr
            // 
            this.taskmgr.BackColor = System.Drawing.Color.White;
            this.taskmgr.Location = new System.Drawing.Point(237, 69);
            this.taskmgr.Name = "taskmgr";
            this.taskmgr.Size = new System.Drawing.Size(63, 50);
            this.taskmgr.TabIndex = 5;
            this.taskmgr.Text = "Task Manager";
            this.taskmgr.UseVisualStyleBackColor = false;
            this.taskmgr.Click += new System.EventHandler(this.button4_Click);
            // 
            // startEx
            // 
            this.startEx.BackColor = System.Drawing.Color.White;
            this.startEx.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.startEx.Location = new System.Drawing.Point(12, 69);
            this.startEx.Name = "startEx";
            this.startEx.Size = new System.Drawing.Size(133, 22);
            this.startEx.TabIndex = 6;
            this.startEx.Text = "Start Explorer";
            this.startEx.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startEx.UseVisualStyleBackColor = false;
            this.startEx.Click += new System.EventHandler(this.button5_Click);
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.White;
            this.about.Location = new System.Drawing.Point(694, 397);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(94, 41);
            this.about.TabIndex = 7;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = false;
            this.about.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.White;
            this.settings.Location = new System.Drawing.Point(632, 397);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(56, 41);
            this.settings.TabIndex = 8;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.button6_Click);
            // 
            // deleterDialog
            // 
            this.deleterDialog.Title = "Select File";
            // 
            // fileDel
            // 
            this.fileDel.BackColor = System.Drawing.Color.White;
            this.fileDel.Location = new System.Drawing.Point(306, 69);
            this.fileDel.Name = "fileDel";
            this.fileDel.Size = new System.Drawing.Size(52, 50);
            this.fileDel.TabIndex = 9;
            this.fileDel.Text = "File Deleter";
            this.fileDel.UseVisualStyleBackColor = false;
            this.fileDel.Click += new System.EventHandler(this.button7_Click);
            // 
            // superFileShortcut
            // 
            this.superFileShortcut.FileName = "file.png";
            this.superFileShortcut.Title = "Select your file (The one that the Super Shortcut refers to.)";
            // 
            // superShortcutSave
            // 
            this.superShortcutSave.AddExtension = false;
            this.superShortcutSave.Title = "Select where to save your Super Shortcut, plus its name. Do NOT add any extension" +
    "s!";
            // 
            // superFolderShortcut
            // 
            this.superFolderShortcut.Description = "Select your folder. (The one you want that the Super Shortcut refers to.)";
            // 
            // faq
            // 
            this.faq.BackColor = System.Drawing.Color.White;
            this.faq.Location = new System.Drawing.Point(570, 397);
            this.faq.Name = "faq";
            this.faq.Size = new System.Drawing.Size(56, 41);
            this.faq.TabIndex = 12;
            this.faq.Text = "FAQ";
            this.faq.UseVisualStyleBackColor = false;
            this.faq.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(792, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ñ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faq);
            this.Controls.Add(this.fileDel);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.about);
            this.Controls.Add(this.startEx);
            this.Controls.Add(this.taskmgr);
            this.Controls.Add(this.programKill);
            this.Controls.Add(this.stopEx);
            this.Controls.Add(this.TitleForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "WinUtil";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleForm1;
        private System.Windows.Forms.Button stopEx;
        private System.Windows.Forms.Button programKill;
        private System.Windows.Forms.Button taskmgr;
        private System.Windows.Forms.Button startEx;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.OpenFileDialog deleterDialog;
        private System.Windows.Forms.Button fileDel;
        private System.Windows.Forms.OpenFileDialog superFileShortcut;
        private System.Windows.Forms.SaveFileDialog superShortcutSave;
        private System.Windows.Forms.FolderBrowserDialog superFolderShortcut;
        private System.Windows.Forms.Button faq;
        private System.Windows.Forms.Label label1;
    }
}

