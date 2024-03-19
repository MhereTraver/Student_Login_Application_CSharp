using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRG282Milestone_2.PresentationLayer
{
    internal class UserLogin
    {

        public string name { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }

        public string WriteToFile()
        {
            string feedback = "";
            string filePath = @"C:\Users\anash\Desktop" + "\\LoginFolder\\" + emailAddress + ".txt"; // you can create your login location
                                                                                                     // and change the C:\Users\anash\Desktop"  "\\LoginFolder\\
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Name :{name}");
                    writer.WriteLine($"Surname :{surname}");
                    writer.WriteLine($"Email :{emailAddress}");
                    writer.WriteLine($"Password :{password}");

                    feedback = "Registered Successfully";

                }
                return feedback;
            }
            catch (Exception e)
            {

                return "Invalid Directory!!";
            }

        }

        public string LoginDetails()
        {
            string feedback = "";
            string filePath = @"C:\Users\anash\Desktop" + "\\LoginFolder\\" + emailAddress + ".txt";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] lineArray = new string[2];
                        lineArray = line.Split(':');
                        if (lineArray[1] == password)
                        {
                            LoginForm loginForm = new LoginForm();
                            MainForm mainForm = new MainForm();
                            feedback = "Access Granted!!";
                            loginForm.Hide();
                            mainForm.Show();

                            return feedback;
                        }
                        else
                        {
                            feedback = "Incorrect Password";
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception)
            {

                feedback = "Incorrect Email Address";
            }
            return feedback;
        }
    }
}
