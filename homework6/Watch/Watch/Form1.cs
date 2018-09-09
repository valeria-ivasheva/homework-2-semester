using System;
using System.Windows.Forms;

namespace Watch
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Инициализирует форму
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string time = "";
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            if (hour < 9)
            {
                time = "0";
            }
            time = time + hour.ToString() + ":";
            if (min < 10)
            {
                time += "0";
            }
            time = time + min.ToString() + ":";
            if (sec < 10)
            {
                time += "0";
            }
            time += sec.ToString();
            WatchLabel.Text = time;
        }
    }
}
