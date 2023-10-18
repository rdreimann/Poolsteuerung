using System;
using System.Device.Gpio;
using System.Drawing;
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

        private void btn_off_Click(object sender, EventArgs e)
        {
            btn_off.BackColor = Color.Lime;
            btn_auto.BackColor = Color.Red;
            btn_timer.BackColor = Color.Red;
            timer_1h.Enabled = false;
            Global.Mintick = 01;
            Global.Sektick = 60;
            btn_timer.Text = "1h aktivieren";
            Ausgang.Checked = false;
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            btn_off.BackColor = Color.Red;
            btn_auto.BackColor = Color.Lime;
            btn_timer.BackColor = Color.Red;
            Global.Mintick = 01;
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
            Global.Mintick = 01;
            Global.Sektick = 59;
            Ausgang.Checked = true;
        }

        private async void timer_abfrage_Tick(object sender, EventArgs e)
        {
            // Pin für output mode konfigurieren
            var pin = 25;
            using var controller = new GpioController();
            controller.OpenPin(pin, PinMode.Output);

            var mittelwert = 0.0;
            //Werte durch die Zwischenspeicher schieben
            Global.labdec5 = Global.labdec4;
            Global.labdec4 = Global.labdec3;
            Global.labdec3 = Global.labdec2;
            Global.labdec2 = Global.labdec1;

            //Durchschnitt berechnen
            mittelwert = Global.labdec5 + Global.labdec4;
            mittelwert = mittelwert + Global.labdec3;
            mittelwert = mittelwert + Global.labdec2;
            mittelwert = mittelwert + Global.labdec1;
            Global.labdec6 = mittelwert / 5;


            //Wert aus dem Nummernlabel ziehen
            //Global.labdec1 = (float)numer1.Value;

            Global.labdec1 = await WebRequest.GetValue();

            //Werte aus den Variablen ausgeben
            label1.Text = string.Format("{0}", Math.Round(Global.labdec1, 2));
            label2.Text = string.Format("{0}", Math.Round(Global.labdec2, 2));
            label3.Text = string.Format("{0}", Math.Round(Global.labdec3, 2));
            label4.Text = string.Format("{0}", Math.Round(Global.labdec4, 2));
            label5.Text = string.Format("{0}", Math.Round(Global.labdec5, 2));
            label6.Text = string.Format("{0}", Math.Round(Global.labdec6, 2));

            // Ausgang schalten

            if (btn_timer.BackColor == Color.Lime)
            {
                Ausgang.Checked = true;
                controller.Write(pin, PinValue.High);
            }

            else if ((btn_auto.BackColor == Color.Lime) & (Global.labdec6 > 2.5) & (Ausgang.Checked == false))
            {
                Ausgang.Checked = true;
                controller.Write(pin, PinValue.High);
            }

            else if ((btn_auto.BackColor == Color.Lime) & (Global.labdec6 > 1.5) & Ausgang.Checked)
            {
                Ausgang.Checked = true;
                controller.Write(pin, PinValue.High);
            }
            else
            {
                Ausgang.Checked = false;
                controller.Write(pin, PinValue.Low);
            }
        }

        private void timer_1h_Tick(object sender, EventArgs e)
        {
            var Sekticker = Convert.ToString(Global.Sektick);
            var Minticker = Convert.ToString(Global.Mintick);
            var Zeitanzeige = Minticker += ":";
            Zeitanzeige += Sekticker;
            btn_timer.Text = Zeitanzeige;

            if (Global.Mintick == 0)
                if (Global.Sektick < 1)
                {
                    btn_timer.Text = "1h aktivieren";
                    timer_1h.Enabled = false;
                    btn_auto.PerformClick();
                    Global.Sektick = 10;
                    Global.Mintick = 1;
                }

            if (Global.Sektick < 1)
            {
                Global.Mintick--;
                Global.Sektick = 60;
            }

            //Ausgang.Checked = true;

            Global.Sektick = Global.Sektick - 1;
        }

        private void numer1_ValueChanged(object sender, EventArgs e)
        {
        }

        private static class Global
        {
            public static int Sektick = 10;
            public static int Mintick = 1;
            public static double labdec1;
            public static double labdec2;
            public static double labdec3;
            public static double labdec4;
            public static double labdec5;
            public static double labdec6;
        }
    }
}