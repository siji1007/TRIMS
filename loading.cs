using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRIMS
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Marquee; 
            progressBar.MarqueeAnimationSpeed = 30; 
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
