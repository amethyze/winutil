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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TitleForm1 = new System.Windows.Forms.Label();
            this.stopEx = new System.Windows.Forms.Button();
            this.taskKill = new System.Windows.Forms.Button();
            this.taskmgr = new System.Windows.Forms.Button();
            this.startEx = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.deleterDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileDel = new System.Windows.Forms.Button();
            this.superFileShortcut = new System.Windows.Forms.OpenFileDialog();
            this.superShortcutSave = new System.Windows.Forms.SaveFileDialog();
            this.superFolderShortcut = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // TitleForm1
            // 
            this.TitleForm1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.TitleForm1.ForeColor = System.Drawing.Color.White;
            this.TitleForm1.Location = new System.Drawing.Point(12, 9);
            this.TitleForm1.Name = "TitleForm1";
            this.TitleForm1.Size = new System.Drawing.Size(293, 44);
            this.TitleForm1.TabIndex = 0;
            this.TitleForm1.Text = "WinUtil\r\n";
            this.TitleForm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleForm1.Click += new System.EventHandler(this.TitleForm1_Click);
            // 
            // stopEx
            // 
            this.stopEx.BackColor = System.Drawing.Color.White;
            this.stopEx.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stopEx.Location = new System.Drawing.Point(12, 56);
            this.stopEx.Name = "stopEx";
            this.stopEx.Size = new System.Drawing.Size(293, 22);
            this.stopEx.TabIndex = 1;
            this.stopEx.Text = "Stop Explorer";
            this.stopEx.UseVisualStyleBackColor = false;
            this.stopEx.Click += new System.EventHandler(this.button1_Click);
            // 
            // taskKill
            // 
            this.taskKill.BackColor = System.Drawing.Color.White;
            this.taskKill.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.taskKill.Location = new System.Drawing.Point(12, 224);
            this.taskKill.Name = "taskKill";
            this.taskKill.Size = new System.Drawing.Size(293, 50);
            this.taskKill.TabIndex = 2;
            this.taskKill.Text = "Program Killer";
            this.taskKill.UseVisualStyleBackColor = false;
            this.taskKill.Click += new System.EventHandler(this.button2_Click);
            // 
            // taskmgr
            // 
            this.taskmgr.BackColor = System.Drawing.Color.White;
            this.taskmgr.Location = new System.Drawing.Point(12, 112);
            this.taskmgr.Name = "taskmgr";
            this.taskmgr.Size = new System.Drawing.Size(293, 50);
            this.taskmgr.TabIndex = 5;
            this.taskmgr.Text = "Task Manager";
            this.taskmgr.UseVisualStyleBackColor = false;
            this.taskmgr.Click += new System.EventHandler(this.button4_Click);
            // 
            // startEx
            // 
            this.startEx.BackColor = System.Drawing.Color.White;
            this.startEx.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.startEx.Location = new System.Drawing.Point(12, 84);
            this.startEx.Name = "startEx";
            this.startEx.Size = new System.Drawing.Size(293, 22);
            this.startEx.TabIndex = 6;
            this.startEx.Text = "Start Explorer";
            this.startEx.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startEx.UseVisualStyleBackColor = false;
            this.startEx.Click += new System.EventHandler(this.button5_Click);
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.White;
            this.about.Location = new System.Drawing.Point(113, 407);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(192, 31);
            this.about.TabIndex = 7;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = false;
            this.about.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.White;
            this.settings.Location = new System.Drawing.Point(12, 407);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(95, 31);
            this.settings.TabIndex = 8;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.button6_Click);
            // 
            // deleterDialog
            // 
            this.deleterDialog.Title = "WinUtil";
            // 
            // fileDel
            // 
            this.fileDel.BackColor = System.Drawing.Color.White;
            this.fileDel.Location = new System.Drawing.Point(12, 168);
            this.fileDel.Name = "fileDel";
            this.fileDel.Size = new System.Drawing.Size(293, 50);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.fileDel);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.about);
            this.Controls.Add(this.startEx);
            this.Controls.Add(this.taskmgr);
            this.Controls.Add(this.taskKill);
            this.Controls.Add(this.stopEx);
            this.Controls.Add(this.TitleForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "WinUtil";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleForm1;
        private System.Windows.Forms.Button stopEx;
        private System.Windows.Forms.Button taskKill;
        private System.Windows.Forms.Button taskmgr;
        private System.Windows.Forms.Button startEx;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.OpenFileDialog deleterDialog;
        private System.Windows.Forms.Button fileDel;
        private System.Windows.Forms.OpenFileDialog superFileShortcut;
        private System.Windows.Forms.SaveFileDialog superShortcutSave;
        private System.Windows.Forms.FolderBrowserDialog superFolderShortcut;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

