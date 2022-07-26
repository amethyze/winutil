using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.IO;
using System.Net;

namespace WinUtil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string winUtilVer = "2.0";
        string winUtilVerXtra = " - The UI Update";

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        string lang = "";
        private void button1_Click(object sender, EventArgs e)
        {
            var Localization = new Localization();
            DialogResult explorerRestart;
            explorerRestart = MessageBox.Show(Localization.form1expRest(lang), Localization.form1expRestTitle(lang), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(explorerRestart == DialogResult.Yes)
            {
                Process.Start("taskkill.exe", "/f /im explorer.exe");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (IsAdministrator())
            {
                new Form2().Show();
            }
            else
            {
                MessageBox.Show("debug RE-ADD ADMIN CHECK ONCE DONE TESTING");
                MessageBox.Show("I'm sorry, but Program Killer can't run without Administrator Privileges. Please, run the application again as Administrator.", "Program Killer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Form2().Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Color backColorDef = Color.FromArgb(0, 0, 0);
        Color txtColorDef = Color.FromArgb(255, 255, 255);
        bool noFile = false;
        string[] colors = { "def" };

        private void Form1_Load(object sender, EventArgs e)
        {
            // Everything below this line handles the WinUtil updater.
            var onlineverpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "onlinever.win");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/SteveeWasTaken/test/main/file.txt", onlineverpath);
            string[] onlinever = File.ReadAllLines(onlineverpath);
            File.Delete(onlineverpath);
            long onlineUnix = long.Parse(onlinever[1]);
            long verUnix = 1658256685;
            if (onlineUnix > verUnix)
            {
                DialogResult updatebox;
                updatebox = MessageBox.Show("You are using an outdated version of WinUtil!\n\nYour Version: " + winUtilVer + winUtilVerXtra + "\nOnline Version: " + onlinever[0] + " " + onlinever[2] + "\n\nDo you wish to update?", "Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (updatebox == DialogResult.Yes)
                {
                    Process.Start("https://github.com/SteveeWasTaken/winutil/releases/latest");
                    System.Windows.Forms.Application.Exit();
                }
            }
            // Everything above this line handles the WinUtil updater.
            var firstrunpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "firstrun");
            try
            {
                string[] colors = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "settings.win"));
            }
            catch (Exception ex)
            {
                noFile = true;

            }
            if (noFile == false)
            {
                string[] colors = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "settings.win"));
                int bgcolorR = Int32.Parse(colors[0]);
                int bgcolorG = Int32.Parse(colors[1]);
                int bgcolorB = Int32.Parse(colors[2]);
                int txtcolorR = Int32.Parse(colors[3]);
                int txtcolorG = Int32.Parse(colors[4]);
                int txtcolorB = Int32.Parse(colors[5]);
                int listboxcolR = Int32.Parse(colors[6]);
                int listboxcolG = Int32.Parse(colors[7]);
                int listboxcolB = Int32.Parse(colors[8]);
                int buttextR = Int32.Parse(colors[9]);
                int buttextG = Int32.Parse(colors[10]);
                int buttextB = Int32.Parse(colors[11]);
                int butbgR = Int32.Parse(colors[12]);
                int butbgG = Int32.Parse(colors[13]);
                int butbgB = Int32.Parse(colors[14]);
                txtColorDef = Color.FromArgb(txtcolorR, txtcolorG, txtcolorB);
                backColorDef = Color.FromArgb(bgcolorR, bgcolorG, bgcolorB);
                this.BackColor = backColorDef;
                TitleForm1.ForeColor = txtColorDef;
                stopEx.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                programKill.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                stopEx.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                programKill.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                about.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                taskmgr.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                about.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                taskmgr.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                startEx.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                settings.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                startEx.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                settings.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                fileDel.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                fileDel.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                faq.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                faq.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
            }
            try
            {
                File.ReadAllText(firstrunpath);
            }
            catch (Exception)
            {
                MessageBox.Show("It seems like this is your first time using WinUtil. I hope you love this program. If you find any bugs or issues, please go to this program's GitHub and tell us more about the issues you found there. Enjoy WinUtil!\n\n-SteveeWasTaken", "Welcome to WinUtil!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.WriteAllText(firstrunpath, "");
            }
            if (IsAdministrator())
            {

            }
            else
            {
                MessageBox.Show("We highly recommend you run WinUtil as administrator.\n\nSome tools will not work properly and might break if not used with administrator. Thank you for using WinUtil!", "Administator Privileges", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bool noLangFile = false;
            try
            {
                lang = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "lang.win"));
            }
            catch (Exception)
            {
                noLangFile = true;
            }
            if (noLangFile == false)
            {
                lang = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "lang.win"));
                if (lang == "English")
                {
                    lang = "EN";
                }
                else if (lang == "Español")
                {
                    lang = "ES";
                }
                else if (lang == "Česky")
                {
                    lang = "CZ";
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("userinit.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("taskmgr.exe");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var Localization = new Localization();
            MessageBox.Show(Localization.form1aboutMsgBox(lang, winUtilVer, winUtilVerXtra), "WinUtil " + winUtilVer, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IsAdministrator())
            {

            }
            else
            {
                DialogResult deleterAdmin;
                deleterAdmin = MessageBox.Show("Some files cannot be deleted without administrator access. With administrator access, you can delete more files than in restricted mode, however this does NOT guarantee that you will be able to delete every file, as some are restricted by Windows.", "Administrator Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            deleterDialog.ShowDialog();
            DialogResult deleterWarn;
            if (deleterDialog.FileName == "")
            {
                MessageBox.Show("You didn't select a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                deleterWarn = MessageBox.Show("The file you selected for deletion is " + deleterDialog.FileName + ". Are you sure this is correct? This isn't reversible!", "File Deleter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleterWarn == DialogResult.Yes)
                {
                    File.Delete(deleterDialog.FileName);
                    MessageBox.Show("File deleted successfully.", "File Deleter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("i forgor to code this xoxo", "Frequently Asked Question", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TitleForm1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult ss;
            ss = MessageBox.Show("Are you going to create a Super Folder Shortcut, or a Super File Shortcut? (Yes for Files, No for Folders)", "Super Shortcut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ss == DialogResult.Yes)
            {
                superFileShortcut.ShowDialog();
                superShortcutSave.ShowDialog();
                Process.Start("cmd.exe", "/c mklink " + superShortcutSave.FileName + superFileShortcut.FileName);
            }
            else
            {
                superFolderShortcut.ShowDialog();
                superShortcutSave.ShowDialog();
                Process.Start("cmd.exe", "/c mklink /d " + superShortcutSave.FileName + " " + superFolderShortcut.SelectedPath);
            }
        }
    }
}
