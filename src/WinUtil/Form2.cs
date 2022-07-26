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
            if (listBox1.Text == "")
            {
                MessageBox.Show("You haven't selected a program from the list below. Please select one and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult tasks;
                tasks = MessageBox.Show("The program \"" + listBox1.Text + "\" was selected. Are you sure this is the one you'd like to terminate? (WARNING: If you select a critical process, the computer may malfunction.)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (tasks == DialogResult.Yes)
                {
                    string s = listBox1.Text.Substring(0, listBox1.Text.Length - 4);
                    foreach (var process in Process.GetProcessesByName(s))
                    {
                        process.Kill();
                    }
                    ListProcesses();
                }
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListProcesses();
        }

        bool noFile = false;
        string lang = "";
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string[] colors = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "winutil", "settings.win"));
            }
            catch (Exception)
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
                var Localization = new Localization();
                button2.Text = Localization.form2Kill(lang);
                button1.Text = Localization.form2Update(lang);
                this.Text = Localization.form2title(lang);
                label1.Text = Localization.form2label(lang);
            }
        }
    }
}

