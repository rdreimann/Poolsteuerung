using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poolsteuerung.models;

namespace Poolsteuerung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static class Global
        {
            public static int Sektick = 59;
            public static int Mintick = 59;
            public static double labdec1 = 0;
            public static double labdec2 = 0;
            public static double labdec3 = 0;
            public static double labdec4 = 0;
            public static double labdec5 = 0;
            public static double labdec6 = 0;
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            btn_off.BackColor = Color.Lime;
            btn_auto.BackColor = Color.Red;
            btn_timer.BackColor = Color.Red;
            timer_1h.Enabled = false;
            Global.Mintick = 59;
            Global.Sektick = 60;
            btn_timer.Text = "1h aktivieren";
            Ausgang.Checked = false;

            Process cmd = new Process();
            cmd.StartInfo.FileName = "/bin/bash";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("pigs w 25 0");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            btn_off.BackColor = Color.Red;
            btn_auto.BackColor = Color.Lime;
            btn_timer.BackColor = Color.Red;
            Global.Mintick = 59;
            Global.Sektick = 60;
            btn_timer.Text = "1h aktivieren";
            timer_1h.Enabled = false;
        }

        private void btn_timer_Click(object sender, EventArgs e)
        {
            btn_off.BackColor = Color.Red;
            btn_auto.BackColor = Color.Red;
            btn_timer.BackColor = Color.Lime;
            timer_1h.Enabled = true;
            Global.Mintick = 59;
            Global.Sektick = 59;
            Ausgang.Checked = true;

            Process cmd = new Process();
            cmd.StartInfo.FileName = "/bin/bash";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("pigs w 25 1");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

        }

        private async void timer_abfrage_Tick(object sender, EventArgs e)
        {

            var mittelwert = 0.0;

            //Werte durch die Zwischenspeicher schieben
            Global.labdec5 = Global.labdec4;
            Global.labdec4 = Global.labdec3;
            Global.labdec3 = Global.labdec2;
            Global.labdec2 = Global.labdec1;

            //Wert aus dem Nummernlabel ziehen

            Global.labdec1 = await WebRequest.GetValue();

            //Durchschnitt berechnen
            mittelwert = Global.labdec5 + Global.labdec4;
            mittelwert = mittelwert + Global.labdec3;
            mittelwert = mittelwert + Global.labdec2;
            mittelwert = mittelwert + Global.labdec1;
            Global.labdec6 = mittelwert / 5;


            //Werte aus den Variablen ausgeben
            label1.Text = String.Format("{0} kW", Math.Round(Global.labdec1, 2));
            label2.Text = String.Format("{0} kW", Math.Round(Global.labdec2, 2));
            label3.Text = String.Format("{0} kW", Math.Round(Global.labdec3, 2));
            label4.Text = String.Format("{0} kW", Math.Round(Global.labdec4, 2));
            label5.Text = String.Format("{0} kW", Math.Round(Global.labdec5, 2));
            label6.Text = String.Format("{0} kW", Math.Round(Global.labdec6, 2));

            // Ausgang schalten

            if (btn_timer.BackColor == Color.Lime)
            {
                Ausgang.Checked = true;

                Process cmd = new Process();
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("pigs w 25 1");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }

            else if (btn_auto.BackColor == Color.Lime & Global.labdec6 < -2.5 & Ausgang.Checked == false)
            {
                Ausgang.Checked = true;


                Process cmd = new Process();
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("pigs w 25 1");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }

            else if (btn_auto.BackColor == Color.Lime & Global.labdec6 < -0.5 & Ausgang.Checked == true)
            {
                Ausgang.Checked = true;

                Process cmd = new Process();
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("pigs w 25 1");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }
            else
            {
                Ausgang.Checked = false;

                Process cmd = new Process();
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();


                cmd.StandardInput.WriteLine("pigs w 25 0");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }
        }

        private void timer_1h_Tick(object sender, EventArgs e)
        {
            string Sekticker = Convert.ToString(Global.Sektick);
            string Minticker = Convert.ToString(Global.Mintick);
            string Zeitanzeige = Minticker += ":";
            Zeitanzeige += Sekticker;
            btn_timer.Text = Zeitanzeige;

            if (Global.Mintick == 0)
            {
                if (Global.Sektick < 1)
                {
                    btn_timer.Text = "1h aktivieren";
                    timer_1h.Enabled = false;
                    btn_auto.PerformClick();
                    Global.Sektick = 10;
                    Global.Mintick = 1;
                }
            }

            if (Global.Sektick < 1)
            {
                Global.Mintick--;
                Global.Sektick = 60;
            }

            Global.Sektick = Global.Sektick - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}