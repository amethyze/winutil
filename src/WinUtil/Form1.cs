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

        readonly string winUtilVer = "2.0.1";
        readonly string winUtilVerXtra = " - Better Settings";
        readonly long verI = 2;

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
        string lang;

        private void button1_Click(object sender, EventArgs e)
        {
            var Localization = new Localization();
            DialogResult explorerRestart;
            explorerRestart = MessageBox.Show(Localization.form1expRest(lang), Localization.form2emptyTitle(lang), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(explorerRestart == DialogResult.Yes)
            {
                Process.Start("taskkill.exe", "/f /im explorer.exe");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var Localization = new Localization();
            if (IsAdministrator())
            {
                new Form2().Show();
            }
            else
            {
                MessageBox.Show(Localization.form1expProgramKiller(lang), Localization.form1taskKill(lang), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Color backColorDef = Color.FromArgb(0, 0, 0);
        Color txtColorDef = Color.FromArgb(255, 255, 255);
        bool noFile;
        string programpath = Application.StartupPath;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Everything below this line handles the WinUtil updater.

            var baseAssetsPath = Path.Combine(programpath, "assets");
            Directory.CreateDirectory(baseAssetsPath);
            var onlineverpath = Path.Combine(baseAssetsPath, "onlinever.win");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://github.com/SteveeWasTaken/winutil/raw/main/gitVersion.txt", onlineverpath);
            string[] onlinever = File.ReadAllLines(onlineverpath);
            File.Delete(onlineverpath);
            long onlineverI = long.Parse(onlinever[1]);
            bool noLangFile = false;
            try
            {
                lang = File.ReadAllText(Path.Combine(baseAssetsPath, "settings", "lang.win"));
            }
            catch (Exception)
            {
                noLangFile = true;
            }
            if (noLangFile == false)
            {
                lang = File.ReadAllText(Path.Combine(baseAssetsPath, "settings", "lang.win"));
                if (lang == "English")
                {
                    lang = "EN";
                }
                else if (lang == "Español")
                {
                    lang = "ES";
                }
            }
            else
            {
                lang = "EN";
            }
            var Localization = new Localization();
            if (onlineverI > verI)
            {
                DialogResult updatebox;
                updatebox = MessageBox.Show(Localization.form1updateAvailable1(lang) + winUtilVer + winUtilVerXtra + Localization.form1updateAvailable2(lang) + onlinever[0] + " " + onlinever[2] + Localization.form1updateAvailable3(lang), Localization.form1updateAvailable4(lang), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (updatebox == DialogResult.Yes)
                {
                    Process.Start("https://github.com/SteveeWasTaken/winutil/releases/latest");
                    Application.Exit();
                }
            }
            // Everything above this line handles the WinUtil updater.
            // Everything below this line handles translations.
            about.Text = Localization.form1about(lang);
            settings.Text = Localization.form1settings(lang);
            startEx.Text = Localization.form1startex(lang);
            stopEx.Text = Localization.form1stopex(lang);
            taskmgr.Text = Localization.form1taskmgr(lang);
            fileDel.Text = Localization.form1fileDel(lang);
            taskKill.Text = Localization.form1taskKill(lang);
            toolTip1.SetToolTip(fileDel, Localization.form1fileDelHelp(lang));
            toolTip1.SetToolTip(taskKill, Localization.form1taskKillHelp(lang));
            toolTip1.SetToolTip(taskmgr, Localization.form1taskmgrHelp(lang));
            // Everything above this line handles translations.
            var firstrunpath = Path.Combine(programpath, "assets", "settings", "firstrun");
            try
            {
                string[] colors = File.ReadAllLines(Path.Combine(baseAssetsPath, "settings", "settings.win"));
            }
            catch (Exception)
            {
                noFile = true;

            }
            if (noFile == false)
            {
                string[] colors = File.ReadAllLines(Path.Combine(baseAssetsPath, "settings", "settings.win"));
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
                taskKill.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                stopEx.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                taskKill.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
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
            }
            bool isOld = true;
            try
            {
                File.ReadAllText(firstrunpath);
            }
            catch (Exception)
            {
                var firstrunpathOLD = Path.Combine(programpath, "WinUtilSettings", "firstrun");
                try
                {
                    File.ReadAllText(firstrunpathOLD);
                }
                catch (Exception)
                {
                    isOld = false;
                    Directory.CreateDirectory(Path.Combine(programpath, "assets", "settings"));
                    MessageBox.Show(Localization.form1welcome(lang), Localization.form1welcomeTitle(lang), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.WriteAllText(firstrunpath, "54 68 61 6e 6b 20 79 6f 75 20 66 6f 72 20 75 73 69 6e 67 20 57 69 6e 55 74 69 6c 21");
                }
                if (isOld)
                {
                    Directory.CreateDirectory(Path.Combine(programpath, "assets"));
                    try
                    {
                        Directory.Move(Path.Combine(programpath, "WinUtilSettings"), Path.Combine(programpath, "assets", "settings"));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Localization.form1failedImport(lang, winUtilVer), Localization.error(lang), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string[] assetsFileList = Directory.GetFiles(baseAssetsPath, "*", SearchOption.AllDirectories);
                        if (assetsFileList.Length != 0)
                        {
                            for (int i = 0; i < assetsFileList.Length; i++)
                            {
                                File.Delete(assetsFileList[i]);
                            }
                        }
                        Directory.Delete(Path.Combine(baseAssetsPath, "settings"));
                        string programpath2 = System.Windows.Forms.Application.ExecutablePath;
                        string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray(); // requires Linq
                        System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
                        startinfo.FileName = programpath2;
                        startinfo.UseShellExecute = true;
                        startinfo.Arguments = string.Join(" ", arguments);
                        Process.Start(startinfo);
                        Application.Exit();
                    }
                }
            }
            if (IsAdministrator())
            {

            }
            else
            {
                MessageBox.Show(Localization.form1adminWarn(lang), Localization.form1adminWarnTitle(lang), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var Localization = new Localization();
            if (IsAdministrator())
            {

            }
            else
            {
                DialogResult deleterAdmin;
                deleterAdmin = MessageBox.Show(Localization.form1delAdmin(lang), Localization.form1fileDelAdminTitle(lang), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            deleterDialog.Title = Localization.form1fileDelTitle(lang);
            deleterDialog.ShowDialog();
            DialogResult deleterWarn;
            if (deleterDialog.FileName == "")
            {
                MessageBox.Show(Localization.form1fileDelNo(lang), Localization.error(lang), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                deleterWarn = MessageBox.Show(Localization.form1fileDelCheck1(lang) + deleterDialog.FileName + Localization.form1fileDelCheck2(lang), Localization.form1fileDel(lang), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleterWarn == DialogResult.Yes)
                {
                    File.Delete(deleterDialog.FileName);
                    MessageBox.Show(Localization.form1fileDelOk(lang), Localization.form1fileDel(lang), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void TitleForm1_Click(object sender, EventArgs e)
        {

        }
    }
}
