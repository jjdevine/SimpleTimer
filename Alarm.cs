using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTimer
{
    public partial class Alarm : Form
    {
        Timer ExpiryTimer;

        Timer GlowingLabelTimer;

        public Alarm(int minutes, int seconds, String text)
        {
            InitializeComponent();
            moveToCorner();

            lMessage.Text = text;
            tbMessage.Text = text;

            GlowingLabelTimer = new Timer();
            GlowingLabelTimer.Interval = (100); //0.05 seconds
            GlowingLabelTimer.Tick += new EventHandler(LabelChangeTimeout);

            String againVal = "";
            if(minutes < 10)
            {
                againVal += "0";
            }

            againVal += minutes;

            againVal += ":";

            if (seconds < 10)
            {
                againVal += "0";
            }

            againVal += seconds;

            tbAgain.Text = againVal;
            begin(minutes, seconds);
        }

        private void begin(int minutes, int seconds)
        {
            lMessage.Text = tbMessage.Text;
            ExpiryTimer = new Timer();
            ExpiryTimer.Interval = ((seconds * 1000) + (minutes * 1000 * 60));
            ExpiryTimer.Tick += new EventHandler(TimeoutHandler);
            ExpiryTimer.Start();
            this.Hide();
            GlowingLabelTimer.Stop();
        }

        private void TimeoutHandler(object sender, EventArgs e)
        {
            this.Show();
            GlowingLabelTimer.Start();
            ExpiryTimer.Stop();
        }

        private void moveToCorner()
        {
            this.Location = new Point(CalculateWindowX(), 10);
        }

        private int CalculateWindowX()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            return workingArea.Right - 10 - Size.Width - 10;
        }

        private void Alarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbAgain_KeyDown(object sender, KeyEventArgs e)
        {
            processKeyDown(sender, e);
        }
        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            processKeyDown(sender, e);
        }

        private void processKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int[] tokens = Utils.ParseTime(tbAgain.Text);
                begin(tokens[0], tokens[1]);
                e.Handled = true;
            }
        }

        private void LabelChangeTimeout(object sender, EventArgs e)
        {
            SetLabelColour();
        }

        int LabelIteration = 0;
        bool LabelIterationIncreasing = true;

        private void SetLabelColour()
        {
            int maxIterations = 10;

            if (LabelIterationIncreasing)
            {
                LabelIteration++;
                if (LabelIteration >= maxIterations)
                {
                    LabelIterationIncreasing = false;
                }
            }
            else
            {
                if (LabelIteration == 1)
                {
                    LabelIterationIncreasing = true;
                }
                LabelIteration--;
            }

            int colorOffset = 25 * LabelIteration;

            lMessage.ForeColor = Color.FromArgb(
                colorOffset,
                255,
                0);
        }


    }
}
