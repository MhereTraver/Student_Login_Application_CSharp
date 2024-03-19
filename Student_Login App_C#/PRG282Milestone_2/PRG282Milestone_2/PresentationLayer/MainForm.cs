using PRG282Milestone_2.DataAccessLayer;
using PRG282Milestone_2.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PRG282Milestone_2.PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // DISPLAYING STUDENTS EVENT
        private void button1_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            dataGridView1.DataSource = handler.DisplayStudent();
        }


        // Event for Uploading aN iMAGE
        private void InsertImageBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.JpG; *.png; *.Gif) | *.JpG; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               studentImage.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }


        //EVENT FOR INSERTING STUDENT
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Initial Catalog=BCITversity;Integrated Security=SSPI");
            SqlCommand cmd;

            cmd = new SqlCommand("Insert Into StudentInfor(StudentNumber, FirstName, LastName,Image, DateOfBirth, Gender, Phone, Address, Module) Values(@StudentNumber, @FirstName, @LastName, @Image, @DateOfBirth, @Gender, @Phone, @Address, @Module)", conn);

            cmd.Parameters.AddWithValue("StudentNumber", txtIDNumber.Text);
            cmd.Parameters.AddWithValue("FirstName", txtName.Text);
            cmd.Parameters.AddWithValue("LastName", txtSurname.Text);
            MemoryStream memoryStream = new MemoryStream();
            studentImage.Image.Save(memoryStream, studentImage.Image.RawFormat);
            cmd.Parameters.AddWithValue("Image", memoryStream.ToArray());
            cmd.Parameters.AddWithValue("DateOfBirth", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("Module", txtModuleCodes.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            
            MessageBox.Show("Student Information inserted successfully!!!!");

        }


        //EVENT FOR UPDATING STUDENT
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Initial Catalog=BCITversity;Integrated Security=SSPI");
            SqlCommand cmd;

            cmd = new SqlCommand("spUpdateInfor", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("StudentNumber", txtIDNumber.Text);
            cmd.Parameters.AddWithValue("FirstName", txtName.Text);
            cmd.Parameters.AddWithValue("LastName", txtSurname.Text);
            MemoryStream memoryStream = new MemoryStream();
            studentImage.Image.Save(memoryStream, studentImage.Image.RawFormat);
            cmd.Parameters.AddWithValue("Image", memoryStream.ToArray());
            cmd.Parameters.AddWithValue("DateOfBirth", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("Module", txtModuleCodes.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Student Information Updated successfully!!!!");
        }

        //EVENT FOR DELETING STUDENT
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteForm = new DeleteStudent();
            deleteForm.Show();
        }


        //EVENT FOR SEARCHING A STUDENT
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchStudent searchForm = new SearchStudent();
            searchForm.Show();
        }


        //EVENT FOR MODULE DISPLAYING
        private void txtModuleCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = txtModuleCodes.Text;
            try
            {
                string connection = "Server=.;Initial Catalog=BCITversity;Integrated Security=SSPI";

                SqlConnection conn = new SqlConnection(connection);

                SqlDataAdapter adapter = new SqlDataAdapter("spDisplayModule", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tableData = new DataTable();

                adapter.Fill(tableData);
                dataGridView2.DataSource = tableData;

            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }


        // DATAGRIDVIEW CELL CLICK EVENT
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtIDNumber.Text = row.Cells["StudentNumber"].Value.ToString();
                txtName.Text = row.Cells["FirstName"].Value.ToString();
                txtSurname.Text = row.Cells["LastName"].Value.ToString();
                dateTimePicker1.Text = row.Cells["DateOfBirth"].Value.ToString();
                txtGender.Text = row.Cells["Gender"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtModuleCodes.Text = row.Cells["Module"].Value.ToString();
                
            }
        }


        // EVENT FOR MODULE
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtModuleCodes.Text = row.Cells["Module"].Value.ToString();
               
            }
        }
    }
}
