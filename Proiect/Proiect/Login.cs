using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbShop;Integrated Security=SSPI;"); // making connection   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTbl WHERE Username='" + textbox_user.Text + "' AND Password='" + textbox_Passw.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                this.Hide();
                new Admin_Form().Show();
            }
            else
                MessageBox.Show("Invalid username or password");

        }

        private void btn_LExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textbox_user.Select();
            textbox_Passw.UseSystemPasswordChar = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void linklabel_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Client_Form().Show();
        }

        private void check_pass_CheckedChanged(object sender, EventArgs e)

        {

            if (check_pass.Checked)
            {
                textbox_Passw.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
                check_pass.Text = "Hide";

            }
            else
            {
                textbox_Passw.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
                check_pass.Text = "View";

            }
        }

    }

}