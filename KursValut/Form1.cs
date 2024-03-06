using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursValut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.02;
        Random rnd = new Random();
        double priceOne;
        double priceTwo;
        int t;
        private void btStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                if (priceOne == 0)
                {
                    priceOne = (double)edCurrencyOne.Value;
                    priceTwo = (double)edCurrencyTwo.Value;
                }
                chart1.Series[0].Points.AddXY(t, priceOne);
                chart1.Series[1].Points.AddXY(t, priceTwo);

                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            priceOne = priceOne * (1 + k * (rnd.NextDouble() - 0.5));
            priceTwo = priceTwo * (1 + k * (rnd.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(t, priceOne);
            chart1.Series[1].Points.AddXY(t, priceTwo);
        }
    }
}
