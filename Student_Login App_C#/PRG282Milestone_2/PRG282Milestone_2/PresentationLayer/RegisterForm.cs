using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PRG282Milestone_2.PresentationLayer
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            UserLogin userInfor = new UserLogin();
            userInfor.name = txtUserName.Text;
            userInfor.surname = txtSurname.Text;
            userInfor.emailAddress = txtEmail.Text;
            userInfor.password = txtPassword.Text;

            MessageBox.Show(userInfor.WriteToFile());
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
