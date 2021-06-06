using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proiect
{
    public partial class Client_Form : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbShop;Integrated Security=SSPI;"); // making connection 
        SqlDataAdapter adap;
        DataTable CarsDT;
        DataTable PCDT;
        DataSet dsCars;
        DataSet dsPc;


        public Client_Form()
        {
            InitializeComponent();
            con.Open();
            dsCars = new DataSet();
            dsPc = new DataSet();
            SqlDataAdapter daCars = new SqlDataAdapter("Select * from Cars_shop", con);
            daCars.Fill(dsCars, "Cars_shop");

            SqlDataAdapter daPc = new SqlDataAdapter("Select * from PC_shop", con);
            daPc.Fill(dsPc, "PC_shop");

            con.Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            

        }
      

        private void btn_Search_PC_Click(object sender, EventArgs e)
        {
            //  ShowData_PC();
            //   ShowData_PCCART();
            SqlDataAdapter daPc = new SqlDataAdapter("Select * from PC_shop", con);
            DataTable dt_test = new DataTable();
            daPc.Fill(dt_test);
            metroGrid4.Rows.Clear();
            foreach (DataRow item in dt_test.Rows)
            {
                int n = metroGrid4.Rows.Add();
                metroGrid4.Rows[n].Cells[0].Value = false;
                metroGrid4.Rows[n].Cells[1].Value = item["PCID"].ToString();
                metroGrid4.Rows[n].Cells[2].Value = item["CPU"].ToString();
                metroGrid4.Rows[n].Cells[3].Value = item["GPU"].ToString();
                metroGrid4.Rows[n].Cells[4].Value = item["RAM"].ToString();
                metroGrid4.Rows[n].Cells[5].Value = item["Storage"].ToString();
                metroGrid4.Rows[n].Cells[6].Value = item["Storage_type"].ToString();
                metroGrid4.Rows[n].Cells[7].Value = item["Price"].ToString();
                metroGrid4.Rows[n].Cells[8].Value = item["ImageUrl"].ToString();

            }
        }

        private void metroGrid4_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            foreach (DataRow dr in dsPc.Tables["PC_shop"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString();

            }
        }




        private void btn_CpyPC_Click(object sender, EventArgs e)
        {
            metroGrid5.Rows.Clear();
            foreach (DataGridViewRow item in metroGrid4.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = metroGrid5.Rows.Add();
                    metroGrid5.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    metroGrid5.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    metroGrid5.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    metroGrid5.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                    metroGrid5.Rows[n].Cells[4].Value = item.Cells[5].Value.ToString();
                    metroGrid5.Rows[n].Cells[5].Value = item.Cells[6].Value.ToString();
                    metroGrid5.Rows[n].Cells[6].Value = item.Cells[7].Value.ToString();
                    metroGrid5.Rows[n].Cells[7].Value = item.Cells[8].Value.ToString();
        
                }
                else
                {
                    metroGrid4.SelectedRows[0].Cells[0].Value = false;
                }
            }
           

        }
        private void btn_Delete_pcC_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE  Cart_PC ", con);

                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            metroGrid5.Rows.Clear();
        }


        private void btn_Save_pcC_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand(" SET IDENTITY_INSERT Cart_PC ON INSERT INTO Cart_PC(PCID, CPU, Price) VALUES (@C1, @C2, @C3) SET IDENTITY_INSERT Cart_PC OFF", con))
            {
                cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@C2", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@C3", SqlDbType.VarChar));
                con.Open();
                foreach (DataGridViewRow row in metroGrid5.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters["@C1"].Value = row.Cells[0].Value;
                        cmd.Parameters["@C2"].Value = row.Cells[1].Value;
                        cmd.Parameters["@C3"].Value = row.Cells[6].Value;
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }


        private void metroGrid4_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)metroGrid4.SelectedRows[0].Cells[0].Value == false)
            {
                metroGrid4.SelectedRows[0].Cells[0].Value = true;
            }
            else
            {
                metroGrid4.SelectedRows[0].Cells[0].Value = false;
            }
        }

        private void metroGrid4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(metroGrid4.Rows[e.RowIndex].Cells["PCID"].FormattedValue);

            con.Open();
            SqlCommand cm = new SqlCommand("Select ImageUrl from PC_shop where PCID = '"  + id + "'", con);
            string img = cm.ExecuteScalar().ToString();
            pictureBox1.Image = Image.FromFile(img);
            con.Close();
        }
        // load cars in page
        private void btn_LoadCarsCart_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daCars = new SqlDataAdapter("Select * from Cars_shop", con);
            DataTable dt_test = new DataTable();
            daCars.Fill(dt_test);
            metroGrid3.Rows.Clear();
            foreach (DataRow item in dt_test.Rows)
            {
                int n = metroGrid3.Rows.Add();
                metroGrid3.Rows[n].Cells[0].Value = false;
                metroGrid3.Rows[n].Cells[1].Value = item["CarID"].ToString();
                metroGrid3.Rows[n].Cells[2].Value = item["Name"].ToString();
                metroGrid3.Rows[n].Cells[3].Value = item["Type"].ToString();
                metroGrid3.Rows[n].Cells[4].Value = item["Price"].ToString();
                metroGrid3.Rows[n].Cells[5].Value = item["Color"].ToString();
                metroGrid3.Rows[n].Cells[6].Value = item["ImageUrl"].ToString();

            }
        }


        // incarcare imagini cars cart
        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(metroGrid3.Rows[e.RowIndex].Cells["CarID"].FormattedValue);

            con.Open();
            SqlCommand cm = new SqlCommand("Select ImageUrl from Cars_shop where CarID = '" + id + "'", con);
            string img = cm.ExecuteScalar().ToString();
            pictureBox2.Image = Image.FromFile(img);
            con.Close();
        }


        // delete cos cart cars 
        private void btn_DeleteCarsCart_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE  Cart_Cars ", con);

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            metroGrid1.Rows.Clear();




        }

        //save cos cart cars
        private void btn_SaveCarsCart_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand(" SET IDENTITY_INSERT Cart_Cars ON INSERT INTO Cart_Cars(CarID, Name, Price) VALUES (@C1, @C2, @C3) SET IDENTITY_INSERT Cart_Cars OFF", con))
            {
                cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@C2", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@C3", SqlDbType.VarChar));
                con.Open();
                foreach (DataGridViewRow row in metroGrid1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters["@C1"].Value = row.Cells[0].Value;
                        cmd.Parameters["@C2"].Value = row.Cells[1].Value;
                        cmd.Parameters["@C3"].Value = row.Cells[3].Value;
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }
        

        // add masini in cart
        private void btn_AddCarsCart_Click(object sender, EventArgs e)
        {
            metroGrid1.Rows.Clear();
            foreach (DataGridViewRow item in metroGrid3.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = metroGrid1.Rows.Add();
                    metroGrid1.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    metroGrid1.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    metroGrid1.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    metroGrid1.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                    metroGrid1.Rows[n].Cells[4].Value = item.Cells[5].Value.ToString();
                    metroGrid1.Rows[n].Cells[5].Value = item.Cells[6].Value.ToString();
         
           
                }
                else
                {
                    metroGrid3.SelectedRows[0].Cells[0].Value = false;
                }
            }

        }

        private void btn_SaveClient_Click(object sender, EventArgs e)
        {

            try
            {
                txt_amount.Text = "0";
                for (int i = 0; i < metroGrid5.Rows.Count; i++)
                {
                    txt_amount.Text = Convert.ToString(double.Parse(txt_amount.Text) + double.Parse(metroGrid5.Rows[i].Cells[6].Value.ToString()));
                }
                for (int i = 0; i < metroGrid1.Rows.Count; i++)
                {
                    txt_amount.Text = Convert.ToString(double.Parse(txt_amount.Text) + double.Parse(metroGrid1.Rows[i].Cells[3].Value.ToString()));
                }


                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Client_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txt_NumeC.Text);
                cmd.Parameters.AddWithValue("@address", txt_AdresaC.Text);
                cmd.Parameters.AddWithValue("@phone", txt_telefonC.Text);
                cmd.Parameters.AddWithValue("@total", txt_amount.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                string message = "Your total is: " + txt_amount.Text + " €. Are you sure you want to proced ?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Thank you!");
                }
                else
                {
                    MessageBox.Show("Good Bye!");
                }
            }
            catch (Exception ex)
            { 
            
            MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Comanda_Click(object sender, EventArgs e)
        {
            

        }
    }
}
