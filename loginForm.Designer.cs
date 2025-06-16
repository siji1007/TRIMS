namespace TRIMS
{
    partial class loginForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHalf = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.bottom_panel = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelHalf.SuspendLayout();
            this.panel2.SuspendLayout();
            this.bottom_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHalf
            // 
            this.panelHalf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHalf.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelHalf.Controls.Add(this.panel2);
            this.panelHalf.Controls.Add(this.bottom_panel);
            this.panelHalf.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelHalf.Location = new System.Drawing.Point(432, 0);
            this.panelHalf.Name = "panelHalf";
            this.panelHalf.Size = new System.Drawing.Size(433, 532);
            this.panelHalf.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 282);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Elephant", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(-9, 90);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(442, 123);
            this.label3.TabIndex = 0;
            this.label3.Text = "LOGIN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottom_panel
            // 
            this.bottom_panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bottom_panel.Controls.Add(this.btn_login);
            this.bottom_panel.Controls.Add(this.label2);
            this.bottom_panel.Controls.Add(this.label1);
            this.bottom_panel.Controls.Add(this.txt_password);
            this.bottom_panel.Controls.Add(this.txt_username);
            this.bottom_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom_panel.Location = new System.Drawing.Point(0, 282);
            this.bottom_panel.Name = "bottom_panel";
            this.bottom_panel.Size = new System.Drawing.Size(433, 250);
            this.bottom_panel.TabIndex = 4;
            this.bottom_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.bottom_panel_Paint);
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_login.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_login.Location = new System.Drawing.Point(181, 174);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(85, 30);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // txt_password
            // 
            this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Black;
            this.txt_password.Location = new System.Drawing.Point(106, 124);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(230, 26);
            this.txt_password.TabIndex = 1;
            // 
            // txt_username
            // 
            this.txt_username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.Black;
            this.txt_username.Location = new System.Drawing.Point(106, 72);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(230, 26);
            this.txt_username.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(61, 4);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TRIMS.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelHalf);
            this.DoubleBuffered = true;
            this.Name = "loginForm";
            this.Size = new System.Drawing.Size(865, 532);
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.panelHalf.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.bottom_panel.ResumeLayout(false);
            this.bottom_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHalf;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Panel bottom_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
