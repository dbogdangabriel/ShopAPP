using Proiect.CarsService;
using Proiect.PCService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Proiect
{
    
    public partial class Admin_Form : MetroFramework.Forms.MetroForm
    {
        private string fileName = ""; 
        EntityState objState = EntityState.Unchanged;
        public Admin_Form()
        {
            InitializeComponent();
            ClearInput();
        }

        void ClearInput()
        {
            textBox_Name.Text = null;
            textBox_Type.Text = null;
            textBox_CarID.Text = null;
            textBox_Color.Text = null;
            textBox_CPU.Text = null;
            textBox_GPU.Text = null;
            textBox_Name.Text = null;
            textBox_PCID.Text = null;
            textBox_Price.Text = null;
            textBox_PricePC.Text = null;
            textBox_Ram.Text = null;
            textBox_Storage.Text = null;
            textBox_Type.Text = null;
            pictureBox1.Text = null;
            pictureBox2.Text = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btn_Import.Enabled = false;

            try
            {
                PCServiceSoapClient client = new PCServiceSoapClient();

                pCBindingSource.DataSource = client.GetAll();
                pcContainer.Enabled = false;
                PC obj = pCBindingSource.Current as PC;
                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.ImageUrlPC))
                        pictureBox2.Image = Image.FromFile(obj.ImageUrlPC);
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                CarsServiceSoapClient client = new CarsServiceSoapClient();

                carsBindingSource.DataSource = client.GetAll();
                pContainer.Enabled = false;
                Cars obj = carsBindingSource.Current as Cars;
                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        pictureBox1.Image = Image.FromFile(obj.ImageUrl);

                        
                    }

                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            pictureBox1.Image = null;
            pContainer.Enabled = true;
            List<Cars> list = ((IEnumerable<Cars>)carsBindingSource.DataSource).ToList();
            list.Add(new Cars());
            carsBindingSource.DataSource = list.AsEnumerable();
            // carsBindingSource.Add(new Cars());
            carsBindingSource.MoveLast();
            textBox_Name.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            objState = EntityState.Changed;
            pContainer.Enabled = true;
            textBox_Name.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            objState = EntityState.Deleted;
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to delete ?", "Message ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    Cars obj = carsBindingSource.Current as Cars;
                    if (obj != null)
                    {
                        CarsServiceSoapClient client = new CarsServiceSoapClient();

                        bool result = client.Delete(obj.CarID);
                        if (result)
                        {
                            carsBindingSource.RemoveCurrent();
                            pContainer.Enabled = false;
                            pictureBox1.Image = null;
                            objState = EntityState.Unchanged;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                carsBindingSource.EndEdit();
                Cars obj = carsBindingSource.Current as Cars;
                if (obj != null)
                {
                    CarsServiceSoapClient client = new CarsServiceSoapClient();
                    if (objState == EntityState.Added)
                    {

                        obj.CarID = client.Insert(obj);

                    }
                    else if (objState == EntityState.Changed)
                    {
                        client.Update(obj);
                    }
                    metroGrid1.Refresh();
                    pContainer.Enabled = false;
                    objState = EntityState.Unchanged;
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            pContainer.Enabled = false;
            carsBindingSource.ResetBindings(false);
            //ClearInput();
            this.Form1_Load(sender, e);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "JPEG|*.jpg|PNG|*.png",
                ValidateNames = true
            })
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    Cars obj = carsBindingSource.Current as Cars;
                    if (obj != null)
                        obj.ImageUrl = ofd.FileName;
                }
            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cars obj = carsBindingSource.Current as Cars;
                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                        pictureBox1.Image = Image.FromFile(obj.ImageUrl);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Tab PC
        private void btnSavePC_Click(object sender, EventArgs e)
        {

            try
            {
                pCBindingSource.EndEdit();
                PC obj = pCBindingSource.Current as PC;
                if (obj != null)
                {

                    PCServiceSoapClient client = new PCServiceSoapClient();
                    if (objState == EntityState.Added)
                    {

                        obj.PCID = client.Insert(obj

                        );

                    }
                    else if (objState == EntityState.Changed)
                    {
                        client.Update(obj);
                    }
                    metroGrid2.Refresh();
                    pcContainer.Enabled = false;
                    objState = EntityState.Unchanged;
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelPC_Click(object sender, EventArgs e)
        {

            pcContainer.Enabled = false;
            pCBindingSource.ResetBindings(false);
            //ClearInput();
            this.Form1_Load(sender, e);
        }

        private void btnAddPC_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            pictureBox2.Image = null;
            pcContainer.Enabled = true;
            List<PC> list = ((IEnumerable<PC>)pCBindingSource.DataSource).ToList();
            list.Add(new PC());
            pCBindingSource.DataSource = list.AsEnumerable();
            // carsBindingSource.Add(new Cars());
            pCBindingSource.MoveLast();
            textBox_CPU.Focus();
        }

        private void btnEditPC_Click(object sender, EventArgs e)
        {

            objState = EntityState.Changed;
            pcContainer.Enabled = true;
            textBox_CPU.Focus();
        }

        private void btnDeletePC_Click(object sender, EventArgs e)
        {

            objState = EntityState.Deleted;
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to delete ?", "Message ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    PC obj = pCBindingSource.Current as PC;
                    if (obj != null)
                    {
                        PCServiceSoapClient client = new PCServiceSoapClient();

                        bool result = client.Delete(obj.PCID);
                        if (result)
                        {
                            pCBindingSource.RemoveCurrent();
                            pcContainer.Enabled = false;
                            pictureBox2.Image = null;
                            objState = EntityState.Unchanged;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowsePC_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "JPEG|*.jpg|PNG|*.png",
                ValidateNames = true
            })
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(ofd.FileName);
                    PC obj = pCBindingSource.Current as PC;
                    if (obj != null)
                        obj.ImageUrlPC = ofd.FileName;
                }
            }
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PC obj = pCBindingSource.Current as PC;
                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.ImageUrlPC))
                        pictureBox2.Image = Image.FromFile(obj.ImageUrlPC);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xDoc = XDocument.Load(fileName);
                List<ProductImport> productList = xDoc.Descendants("product").Select
                    (product =>
                    new ProductImport
                    {
                        Id = product.Element("id").Value,
                        Name = product.Element("name").Value,
                        Price = Convert.ToDecimal(product.Element("price").Value),
                        Quantity = Convert.ToInt32(product.Element("quantity").
                        Value)
                    }).ToList();
                using (importEntities de = new importEntities())
                {
                    foreach (var i in productList)
                    {
                        var v = de.ProductImports.Where(a => a.Id.Equals
                         (i.Id)).FirstOrDefault();
                        if (v != null)
                        {
                            v.Id = i.Id;
                            v.Name = i.Name;
                            v.Price = i.Price;
                            v.Quantity = i.Quantity;
                        }
                        else
                        {
                            de.ProductImports.Add(i);
                        }
                        }
                    de.SaveChanges();
                    this.dataGridViewProduct.DataSource = de.ProductImports.ToList();
                    MessageBox.Show("Done");
                    }
                }
                    
            
            catch (Exception ex)
            {
                MessageBox.Show("Can't import xml file");
            }
        }

        private void btn_BrowXML_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Please select a xml file";
                openFileDialog.Filter = "XML File|*.xml";
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.btn_Import.Enabled = true;
                    this.fileName = openFileDialog.FileName;
                    MessageBox.Show(this.fileName);
                }
            
        }
    }
}