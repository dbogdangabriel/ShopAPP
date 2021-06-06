
namespace Proiect
{
    partial class Login
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
            this.btn_Login = new MetroFramework.Controls.MetroButton();
            this.btn_LExit = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.linklabel_login = new System.Windows.Forms.LinkLabel();
            this.check_pass = new MetroFramework.Controls.MetroCheckBox();
            this.textbox_user = new MetroFramework.Controls.MetroTextBox();
            this.textbox_Passw = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(78, 187);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(109, 37);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseSelectable = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_LExit
            // 
            this.btn_LExit.Location = new System.Drawing.Point(245, 187);
            this.btn_LExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_LExit.Name = "btn_LExit";
            this.btn_LExit.Size = new System.Drawing.Size(109, 37);
            this.btn_LExit.TabIndex = 1;
            this.btn_LExit.Text = "Exit";
            this.btn_LExit.UseSelectable = true;
            this.btn_LExit.Click += new System.EventHandler(this.btn_LExit_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(37, 66);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Username: ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(37, 124);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Password:";
            // 
            // linklabel_login
            // 
            this.linklabel_login.AutoSize = true;
            this.linklabel_login.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklabel_login.LinkColor = System.Drawing.Color.Teal;
            this.linklabel_login.Location = new System.Drawing.Point(69, 238);
            this.linklabel_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linklabel_login.Name = "linklabel_login";
            this.linklabel_login.Size = new System.Drawing.Size(285, 26);
            this.linklabel_login.TabIndex = 4;
            this.linklabel_login.TabStop = true;
            this.linklabel_login.Text = "If you are a client, press here ";
            this.linklabel_login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_login_LinkClicked);
            // 
            // check_pass
            // 
            this.check_pass.AutoSize = true;
            this.check_pass.Location = new System.Drawing.Point(307, 134);
            this.check_pass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.check_pass.Name = "check_pass";
            this.check_pass.Size = new System.Drawing.Size(48, 15);
            this.check_pass.TabIndex = 5;
            this.check_pass.Text = "Hide";
            this.check_pass.UseSelectable = true;
            this.check_pass.CheckedChanged += new System.EventHandler(this.check_pass_CheckedChanged);
            // 
            // textbox_user
            // 
            // 
            // 
            // 
            this.textbox_user.CustomButton.Image = null;
            this.textbox_user.CustomButton.Location = new System.Drawing.Point(86, 2);
            this.textbox_user.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textbox_user.CustomButton.Name = "";
            this.textbox_user.CustomButton.Size = new System.Drawing.Size(17, 19);
            this.textbox_user.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textbox_user.CustomButton.TabIndex = 1;
            this.textbox_user.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textbox_user.CustomButton.UseSelectable = true;
            this.textbox_user.CustomButton.Visible = false;
            this.textbox_user.Lines = new string[0];
            this.textbox_user.Location = new System.Drawing.Point(135, 66);
            this.textbox_user.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textbox_user.MaxLength = 32767;
            this.textbox_user.Name = "textbox_user";
            this.textbox_user.PasswordChar = '\0';
            this.textbox_user.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textbox_user.SelectedText = "";
            this.textbox_user.SelectionLength = 0;
            this.textbox_user.SelectionStart = 0;
            this.textbox_user.ShortcutsEnabled = true;
            this.textbox_user.Size = new System.Drawing.Size(141, 28);
            this.textbox_user.TabIndex = 6;
            this.textbox_user.UseSelectable = true;
            this.textbox_user.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textbox_user.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textbox_Passw
            // 
            // 
            // 
            // 
            this.textbox_Passw.CustomButton.Image = null;
            this.textbox_Passw.CustomButton.Location = new System.Drawing.Point(85, 2);
            this.textbox_Passw.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textbox_Passw.CustomButton.Name = "";
            this.textbox_Passw.CustomButton.Size = new System.Drawing.Size(19, 20);
            this.textbox_Passw.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textbox_Passw.CustomButton.TabIndex = 1;
            this.textbox_Passw.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textbox_Passw.CustomButton.UseSelectable = true;
            this.textbox_Passw.CustomButton.Visible = false;
            this.textbox_Passw.Lines = new string[0];
            this.textbox_Passw.Location = new System.Drawing.Point(135, 124);
            this.textbox_Passw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textbox_Passw.MaxLength = 32767;
            this.textbox_Passw.Name = "textbox_Passw";
            this.textbox_Passw.PasswordChar = '\0';
            this.textbox_Passw.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textbox_Passw.SelectedText = "";
            this.textbox_Passw.SelectionLength = 0;
            this.textbox_Passw.SelectionStart = 0;
            this.textbox_Passw.ShortcutsEnabled = true;
            this.textbox_Passw.Size = new System.Drawing.Size(141, 30);
            this.textbox_Passw.TabIndex = 7;
            this.textbox_Passw.UseSelectable = true;
            this.textbox_Passw.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textbox_Passw.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Login
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(413, 271);
            this.Controls.Add(this.textbox_Passw);
            this.Controls.Add(this.textbox_user);
            this.Controls.Add(this.check_pass);
            this.Controls.Add(this.linklabel_login);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btn_LExit);
            this.Controls.Add(this.btn_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_Login;
        private MetroFramework.Controls.MetroButton btn_LExit;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.LinkLabel linklabel_login;
        private MetroFramework.Controls.MetroCheckBox check_pass;
        private MetroFramework.Controls.MetroTextBox textbox_user;
        private MetroFramework.Controls.MetroTextBox textbox_Passw;
    }
}