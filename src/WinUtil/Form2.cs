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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ListProcesses();
        }


        private void ListProcesses()
        {
            listBox1.Items.Clear();
            Process[] processCollection = Process.GetProcesses();
            string[] processList = new string[processCollection.Length];
            for (int i = 0; i < processCollection.Length; i++)
            {
                processList[i] = processCollection[i].ProcessName;
            }
            string[] filteredList = processList.Distinct().ToArray();

            foreach (string s in filteredList)
            {
                listBox1.Items.Add(s + ".exe");
            }
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Localization = new Localization();
            if (listBox1.Text == "")
            {
                MessageBox.Show(Localization.form2empty(lang), Localization.form2emptyTitle(lang), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult tasks;
                tasks = MessageBox.Show(Localization.form2check1(lang) + listBox1.Text + Localization.form2check2(lang), Localization.form2emptyTitle(lang), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (tasks == DialogResult.Yes)
                {
                    string s = listBox1.Text.Substring(0, listBox1.Text.Length - 4);
                    bool hadError = false;
                    foreach (var process in Process.GetProcessesByName(s))
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch (Exception)
                        {
                            if (hadError)
                            {

                            }
                            else
                            {
                                MessageBox.Show(Localization.form2failedKill(lang), Localization.error(lang), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hadError = true;
                            }
                        }
                    }
                    ListProcesses();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListProcesses();
        }

        bool noFile = false;
        string lang = "";
        string programpath = Application.StartupPath;

        private void Form2_Load(object sender, EventArgs e)
        {
            var baseAssetsPath = Path.Combine(programpath, "assets");
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
                label1.ForeColor = Color.FromArgb(txtcolorR, txtcolorG, txtcolorB);
                listBox1.ForeColor = Color.FromArgb(txtcolorR, txtcolorG, txtcolorB);
                this.BackColor = Color.FromArgb(bgcolorR, bgcolorG, bgcolorB);
                listBox1.BackColor = Color.FromArgb(listboxcolR, listboxcolG, listboxcolB);
                button1.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button2.BackColor = Color.FromArgb(butbgR, butbgG, butbgB);
                button1.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
                button2.ForeColor = Color.FromArgb(buttextR, buttextG, buttextB);
            }
            bool noLangFile = false;
            try
            {
                lang = File.ReadAllText(Path.Combine(programpath, "WinUtilSettings", "lang.win"));
            }
            catch (Exception)
            {
                noLangFile = true;
            }
            var Localization = new Localization();
            if (noLangFile == false)
            {
                lang = File.ReadAllText(Path.Combine(programpath, "WinUtilSettings", "lang.win"));
                if (lang == "English")
                {
                    lang = "EN";
                }
                else if (lang == "Español")
                {
                    lang = "ES";
                }
                button2.Text = Localization.form2Kill(lang);
                button1.Text = Localization.form2Update(lang);
                this.Text = Localization.form1taskKill(lang);
                label1.Text = Localization.form2label(lang);

            }
        }
    }
}

