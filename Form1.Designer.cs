namespace clientManagementApp
{
    partial class Form1
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
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.loginBtn = new FontAwesome.Sharp.IconButton();
            this.closeBtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Monero;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Brands;
            this.iconPictureBox1.IconSize = 96;
            this.iconPictureBox1.Location = new System.Drawing.Point(99, 65);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(96, 100);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(21, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Manager";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox2.IconSize = 18;
            this.iconPictureBox2.Location = new System.Drawing.Point(42, 261);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 2;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconPictureBox3.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox3.IconSize = 18;
            this.iconPictureBox3.Location = new System.Drawing.Point(42, 315);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox3.TabIndex = 3;
            this.iconPictureBox3.TabStop = false;
            this.iconPictureBox3.Click += new System.EventHandler(this.iconPictureBox3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(42, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 1);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Location = new System.Drawing.Point(43, 335);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 1);
            this.panel2.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtUserName.Location = new System.Drawing.Point(71, 261);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 16);
            this.txtUserName.TabIndex = 6;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserPassword.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtUserPassword.Location = new System.Drawing.Point(71, 314);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '●';
            this.txtUserPassword.Size = new System.Drawing.Size(194, 16);
            this.txtUserPassword.TabIndex = 7;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.loginBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.loginBtn.IconColor = System.Drawing.Color.Black;
            this.loginBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loginBtn.Location = new System.Drawing.Point(12, 382);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(271, 35);
            this.loginBtn.TabIndex = 8;
            this.loginBtn.Text = "Log In";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.closeBtn.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.closeBtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.closeBtn.IconSize = 14;
            this.closeBtn.Location = new System.Drawing.Point(256, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(36, 24);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(292, 447);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iconPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPassword;
        private FontAwesome.Sharp.IconButton loginBtn;
        private FontAwesome.Sharp.IconButton closeBtn;
    }
}

