using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinUtil
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        bool noFile = false;
        string lang = "";
        private void Form4_Load(object sender, EventArgs e)
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
            }
        }
    }
}
