using PRG282Milestone_2.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282Milestone_2.PresentationLayer
{
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        // Delete Student
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            handler.DeleteStudent(int.Parse(txtDelete.Text));

            MessageBox.Show("Student Information Deleted successfully!!!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}
