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
    public partial class SearchStudent : Form
    {
        public SearchStudent()
        {
            InitializeComponent();
        }

        // Search Student
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            dataGridView1.DataSource = handler.SearchStudent(int.Parse(txtSearch.Text));
        }

        private void BtnBack1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();        
            mainForm.Show();
            this.Close();
        }
    }
}
