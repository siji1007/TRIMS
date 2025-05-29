using System;
using System.Windows.Forms;

namespace TRIMS
{
    public partial class loginForm : UserControl
    {
        private TRIMS mainForm;

        public loginForm(TRIMS form)
        {
            InitializeComponent();
            this.Resize += loginForm_Resize;
            mainForm = form;
        }

        private void loginForm_Resize(object sender, EventArgs e)
        {
            // Responsive width for panelHalf
            panelHalf.Width = this.ClientSize.Width / 2;
            panelHalf.Left = (this.ClientSize.Width - panelHalf.Width) / 2;

            // Responsive height for bottom_panel
            bottom_panel.Height = this.ClientSize.Height / 2;
            bottom_panel.Top = this.ClientSize.Height - bottom_panel.Height;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "admin" && txt_password.Text == "admin")
            {
                mainForm.LoadDashboard();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bottom_panel_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txt_username_TextChanged(object sender, EventArgs e) { }
        private void loginForm_Load(object sender, EventArgs e) { }
    }
}
