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

namespace WinUtil
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        string bgcolorR = "0";
        string bgcolorG = "0";
        string bgcolorB = "0";
        string txtcolorR = "255";
        string txtcolorG = "255";
        string txtcolorB = "255";
        string listboxcolR = "0";
        string listboxcolG = "0";
        string listboxcolB = "0";
        string buttextR = "255";
        string buttextG = "255";
        string buttextB = "255";
        string butbgR = "0";
        string butbgG = "0";
        string butbgB = "0";
        bool noFile = false;
        bool noLangFile = false;
        string lang = "";
        string programpath = Application.StartupPath;
        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                string[] colors = File.ReadAllLines(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
            }
            catch (Exception)
            {

                noFile = true;
            }
            try
            {
                lang = File.ReadAllText(Path.Combine(programpath, "WinUtilSettings", "lang.win"));
            }
            catch (Exception)
            {
                noLangFile = true;
            }
            if (noFile == false)
            {
                string[] colors = File.ReadAllLines(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
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
                this.BackColor = Color.FromArgb(bgcolorR, bgcolorG, bgcolorB);
                button1.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button2.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button3.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button4.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button6.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button7.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button8.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button9.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button1.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button2.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button3.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button4.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button6.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button7.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button8.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button9.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                label1.ForeColor = Color.FromArgb(txtcolorR, txtcolorG, txtcolorB);
            }
            if (noLangFile == false)
            {
                lang = File.ReadAllText(Path.Combine(programpath, "WinUtilSettings", "lang.win"));
                comboBox1.Text = lang;
                if (lang == "English")
                {
                    lang = "EN";
                    comboBox1.Text = "English";
                }
                else if (lang == "Español")
                {
                    lang = "ES";
                    comboBox1.Text = "Español";
                }
                var Localization = new Localization();
                button1.Text = Localization.form3button1(lang);
                button2.Text = Localization.form3button2(lang);
                button3.Text = Localization.form3button3(lang);
                button4.Text = Localization.form3button4(lang);
                button5.Text = Localization.form3button5(lang);
                button6.Text = Localization.form3button6(lang);
                button7.Text = Localization.form3button7(lang);
                button8.Text = Localization.form3button8(lang);
                this.Text = Localization.form3Title(lang);
                label1.Text = Localization.form3Label(lang);
                linkLabel1.Text = Localization.form3url2(lang);
                linkLabel2.Text = Localization.form3url1(lang);
                linkLabel3.Text = Localization.form3url3(lang);
                toolTip1.SetToolTip(button9, Localization.form3button9Help(lang));
            }
            else
            {
                comboBox1.Text = "English";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgCh = true;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = button1.ForeColor;
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = MyDialog.Color;
            }
            bgcolorR = MyDialog.Color.R.ToString();
            bgcolorG = MyDialog.Color.G.ToString();
            bgcolorB = MyDialog.Color.B.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtCh = true;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = button1.ForeColor;
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                label1.ForeColor = MyDialog.Color;
            }
            txtcolorR = MyDialog.Color.R.ToString();
            txtcolorG = MyDialog.Color.G.ToString();
            txtcolorB = MyDialog.Color.B.ToString();
        }

        bool txtCh = false;
        bool bgCh = false;
        bool listBoxCh = false;
        bool butTxtCh = false;
        bool butBgCh = false;

        private void button2_Click(object sender, EventArgs e)
        {

            string programpath = Application.StartupPath;
            bool test = false;
            try
            {
                string[] colors = File.ReadAllLines(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
            }
            catch (Exception)
            {
                test = true;
            }
            if (test)
            {

            }
            else
            {
                string[] colors = File.ReadAllLines(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
                if (txtCh != true)
                {
                    txtcolorR = colors[3];
                    txtcolorG = colors[4];
                    txtcolorB = colors[5];
                }
                if (bgCh != true)
                {
                    bgcolorR = colors[0];
                    bgcolorG = colors[1];
                    bgcolorB = colors[2];
                }
                if (listBoxCh != true)
                {
                    listboxcolR = colors[6];
                    listboxcolG = colors[7];
                    listboxcolB = colors[8];
                }
                if (butTxtCh != true)
                {
                    buttextR = colors[9];
                    buttextG = colors[10];
                    buttextB = colors[11];
                }
                if (butBgCh != true)
                {
                    butbgR = colors[12];
                    butbgG = colors[13];
                    butbgB = colors[14];
                }
            }
            string[] settingsArray = new string[] { bgcolorR, bgcolorG, bgcolorB, txtcolorR, txtcolorG, txtcolorB, listboxcolR, listboxcolG, listboxcolB, buttextR, buttextG, buttextB, butbgR, butbgG, butbgB};
            var settingsPath = Path.Combine(programpath, "WinUtilSettings", "settings.win");
            File.WriteAllLines(settingsPath, settingsArray);
            string langDrop = comboBox1.Text;
            try
            {
                string lang = File.ReadAllText(Path.Combine(programpath, "WinUtilSettings", "lang.win"));
            }
            catch (Exception)
            {
            }
            var langPath = Path.Combine(programpath, "WinUtilSettings", "lang.win");
            File.WriteAllText(langPath, langDrop);
            string programpath2 = System.Windows.Forms.Application.ExecutablePath;
            string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray(); // requires Linq
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.FileName = programpath2;
            startinfo.UseShellExecute = true;
            startinfo.Arguments = string.Join(" ", arguments);
            Process.Start(startinfo);
            Application.Exit();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBoxCh = true;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = button1.ForeColor;
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

            }
            listboxcolR = MyDialog.Color.R.ToString();
            listboxcolG = MyDialog.Color.G.ToString();
            listboxcolB = MyDialog.Color.B.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var Localization = new Localization();
            DialogResult delsets;
            delsets = MessageBox.Show(Localization.form3resetSettings(lang), Localization.form3resetSettingsTitle(lang), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (delsets == DialogResult.OK)
            {
                File.Delete(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
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

        private void button8_Click(object sender, EventArgs e)
        {
            butTxtCh = true;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = button1.ForeColor;
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                button1.ForeColor = MyDialog.Color;
                button2.ForeColor = MyDialog.Color;
                button3.ForeColor = MyDialog.Color;
                button4.ForeColor = MyDialog.Color;
                button6.ForeColor = MyDialog.Color;
                button7.ForeColor = MyDialog.Color;
                button8.ForeColor = MyDialog.Color;
                button9.ForeColor = MyDialog.Color;
            }
            buttextR = MyDialog.Color.R.ToString();
            buttextG = MyDialog.Color.G.ToString();
            buttextB = MyDialog.Color.B.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            butBgCh = true;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = button1.ForeColor;
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = MyDialog.Color;
                button2.BackColor = MyDialog.Color;
                button3.BackColor = MyDialog.Color;
                button4.BackColor = MyDialog.Color;
                button6.BackColor = MyDialog.Color;
                button7.BackColor = MyDialog.Color;
                button8.BackColor = MyDialog.Color;
                button9.BackColor = MyDialog.Color;
            }
            butbgR = MyDialog.Color.R.ToString();
            butbgG = MyDialog.Color.G.ToString();
            butbgB = MyDialog.Color.B.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(programpath, "WinUtilSettings"));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SteveeWasTaken/winutil/issues/new");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SteveeWasTaken/winutil");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SteveeWasTaken");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string programpath = Application.StartupPath;
            bool test = false;
            try
            {
                string[] colors = File.ReadAllLines(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
            }
            catch (Exception)
            {
                test = true;
            }
            if (test)
            {

            }
            else
            {
                string[] colors = File.ReadAllLines(Path.Combine(programpath, "WinUtilSettings", "settings.win"));
                if (txtCh != true)
                {
                    txtcolorR = colors[3];
                    txtcolorG = colors[4];
                    txtcolorB = colors[5];
                }
                if (bgCh != true)
                {
                    bgcolorR = colors[0];
                    bgcolorG = colors[1];
                    bgcolorB = colors[2];
                }
                if (listBoxCh != true)
                {
                    listboxcolR = colors[6];
                    listboxcolG = colors[7];
                    listboxcolB = colors[8];
                }
                if (butTxtCh != true)
                {
                    buttextR = colors[9];
                    buttextG = colors[10];
                    buttextB = colors[11];
                }
                if (butBgCh != true)
                {
                    butbgR = colors[12];
                    butbgG = colors[13];
                    butbgB = colors[14];
                }
            }
            string[] settingsArray = new string[] { bgcolorR, bgcolorG, bgcolorB, txtcolorR, txtcolorG, txtcolorB, listboxcolR, listboxcolG, listboxcolB, buttextR, buttextG, buttextB, butbgR, butbgG, butbgB };
            var settingsPath = Path.Combine(programpath, "WinUtilSettings", "settings.win");
            File.WriteAllLines(settingsPath, settingsArray);
            string langDrop = comboBox1.Text;
            try
            {
                string lang = File.ReadAllText(Path.Combine(programpath, "WinUtilSettings", "lang.win"));
            }
            catch (Exception)
            {
            }
            var langPath = Path.Combine(programpath, "WinUtilSettings", "lang.win");
            File.WriteAllText(langPath, langDrop);
            string programpath2 = System.Windows.Forms.Application.ExecutablePath;
            string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray(); // requires Linq
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.FileName = programpath2;
            startinfo.UseShellExecute = true;
            startinfo.Verb = "runas";
            startinfo.Arguments = String.Join(" ", arguments);
            bool adminYes = true;
            var Localization = new Localization();
            try
            {
                Process.Start(startinfo);
            }
            catch (Exception)
            {
                adminYes = false;
            }
            if (adminYes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show(Localization.form3failedAdmin(lang), Localization.error(lang), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
