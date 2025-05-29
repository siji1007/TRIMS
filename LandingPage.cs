using System;
using System.Windows.Forms;

namespace TRIMS
{
    public partial class TRIMS : Form
    {
        public TRIMS()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            loginForm login = new loginForm(this); 
            login.Dock = DockStyle.Fill;
            panelMain.Controls.Add(login);
        }

        public void LoadDashboard()
        {
            panelMain.Controls.Clear();
            dashboard dashboard = new dashboard(); 
            dashboard.Dock = DockStyle.Fill;
            panelMain.Controls.Add(dashboard);
        }
    }
}
