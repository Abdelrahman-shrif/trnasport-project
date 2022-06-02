namespace WindowsFormsApp1
{
    partial class AdminLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.AdminLbl = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.AdminPasswordTb = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 40);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox8.Location = new System.Drawing.Point(262, 9);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(34, 25);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 53;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // AdminLbl
            // 
            this.AdminLbl.AutoSize = true;
            this.AdminLbl.Font = new System.Drawing.Font("Averia", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.AdminLbl.ForeColor = System.Drawing.Color.RoyalBlue;
            this.AdminLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AdminLbl.Location = new System.Drawing.Point(138, 242);
            this.AdminLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AdminLbl.Name = "AdminLbl";
            this.AdminLbl.Size = new System.Drawing.Size(41, 17);
            this.AdminLbl.TabIndex = 2;
            this.AdminLbl.Text = "Back";
            this.AdminLbl.Click += new System.EventHandler(this.AdminLbl_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Averia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LoginBtn.Location = new System.Drawing.Point(113, 200);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(86, 26);
            this.LoginBtn.TabIndex = 1;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Averia", 13.2F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(82, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "Admin Password";
            // 
            // AdminPasswordTb
            // 
            this.AdminPasswordTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdminPasswordTb.Font = new System.Drawing.Font("Averia", 12F, System.Drawing.FontStyle.Bold);
            this.AdminPasswordTb.Location = new System.Drawing.Point(86, 159);
            this.AdminPasswordTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AdminPasswordTb.Name = "AdminPasswordTb";
            this.AdminPasswordTb.PasswordChar = '*';
            this.AdminPasswordTb.Size = new System.Drawing.Size(147, 27);
            this.AdminPasswordTb.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(95, 9);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(119, 114);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // AdminLogin
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 267);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.AdminLbl);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AdminPasswordTb);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label AdminLbl;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AdminPasswordTb;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}