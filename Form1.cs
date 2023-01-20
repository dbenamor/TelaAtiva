using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace TelaAtiva
{
    public partial class Form1 : Form
    {
        Stopwatch cronometro = new Stopwatch();
        private bool _start;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnPlay.Focus();
            toolTip1.SetToolTip(BtnPlay, "Start");
            toolTip2.SetToolTip(BtnStop, "Stop");
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblContador.Text = String.Format("{0:00}:{1:00}:{2:00}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds);
        }

        private void Start()
        {
            _start = true;
            cronometro.Reset();
            cronometro.Start();

            while (_start == true)
            {
                SendKeys.Send("F5");

                Thread.Sleep(1000);
                Application.DoEvents();
            }
        }

        private void Stop()
        {
            _start = false;
            cronometro.Stop();
            cronometro.Reset();
        }

    }
}
