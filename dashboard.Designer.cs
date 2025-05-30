namespace TRIMS
{
    partial class dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.civil_status = new System.Windows.Forms.ComboBox();
            this.purok_cbox = new System.Windows.Forms.ComboBox();
            this.age_cbox = new System.Windows.Forms.ComboBox();
            this.dataShow = new System.Windows.Forms.DataGridView();
            this.TOTAL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.civil_status);
            this.panel1.Controls.Add(this.purok_cbox);
            this.panel1.Controls.Add(this.age_cbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 50);
            this.panel1.TabIndex = 0;
            // 
            // civil_status
            // 
            this.civil_status.FormattingEnabled = true;
            this.civil_status.Location = new System.Drawing.Point(584, 9);
            this.civil_status.Name = "civil_status";
            this.civil_status.Size = new System.Drawing.Size(171, 21);
            this.civil_status.TabIndex = 2;
            this.civil_status.SelectedIndexChanged += new System.EventHandler(this.civil_status_SelectedIndexChanged);
            // 
            // purok_cbox
            // 
            this.purok_cbox.FormattingEnabled = true;
            this.purok_cbox.Location = new System.Drawing.Point(313, 9);
            this.purok_cbox.Name = "purok_cbox";
            this.purok_cbox.Size = new System.Drawing.Size(171, 21);
            this.purok_cbox.TabIndex = 1;
            this.purok_cbox.SelectedIndexChanged += new System.EventHandler(this.purok_cbox_SelectedIndexChanged);
            // 
            // age_cbox
            // 
            this.age_cbox.FormattingEnabled = true;
            this.age_cbox.Location = new System.Drawing.Point(61, 9);
            this.age_cbox.Name = "age_cbox";
            this.age_cbox.Size = new System.Drawing.Size(171, 21);
            this.age_cbox.TabIndex = 0;
            this.age_cbox.SelectedIndexChanged += new System.EventHandler(this.age_cbox_SelectedIndexChanged);
            // 
            // dataShow
            // 
            this.dataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataShow.Location = new System.Drawing.Point(0, 50);
            this.dataShow.Name = "dataShow";
            this.dataShow.Size = new System.Drawing.Size(859, 438);
            this.dataShow.TabIndex = 1;
            this.dataShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataShow_CellContentClick);
            // 
            // TOTAL
            // 
            this.TOTAL.AutoSize = true;
            this.TOTAL.Dock = System.Windows.Forms.DockStyle.Left;
            this.TOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TOTAL.Location = new System.Drawing.Point(0, 488);
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.Size = new System.Drawing.Size(82, 24);
            this.TOTAL.TabIndex = 2;
            this.TOTAL.Text = "TOTAL: ";
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TOTAL);
            this.Controls.Add(this.dataShow);
            this.Controls.Add(this.panel1);
            this.Name = "dashboard";
            this.Size = new System.Drawing.Size(859, 568);
            this.Load += new System.EventHandler(this.dashboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox civil_status;
        private System.Windows.Forms.ComboBox purok_cbox;
        private System.Windows.Forms.ComboBox age_cbox;
        private System.Windows.Forms.DataGridView dataShow;
        private System.Windows.Forms.Label TOTAL;
    }
}
