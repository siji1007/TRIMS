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
            UserControl1 dashboard = new UserControl1();
            dashboard.Dock = DockStyle.Fill; // Makes it fill the parent panel
            panelMain.Controls.Add(dashboard);
        }
    }
}
