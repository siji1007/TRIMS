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

            // Attach KeyDown event handlers
            txt_username.KeyDown += TxtFields_KeyDown;
            txt_password.KeyDown += TxtFields_KeyDown;
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
            if (txt_username.Text == "a" && txt_password.Text == "a")
            {
                mainForm.LoadDashboard();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Trigger login when Enter is pressed in either textbox
        private void TxtFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
              
            }
        }

        private void bottom_panel_Paint(object sender, PaintEventArgs e) { }
        private void loginForm_Load(object sender, EventArgs e) { }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
