using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;

namespace MDB.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser r = new RegisterUser();
            r.Closed += (s, args) => this.Close();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Username = textBox1.Text;
            String password = textBox2.Text;
            User u = new User();
            Form1 f = new Form1();
            if (((String)textBox1.Text) == "admin" && ((String)textBox2.Text) == "admin")
            {
                MultimediaDB.setSessionUsername("admin");
                this.Hide();
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else
            {
                IObjectSet users = MDB.MultimediaDB.db.QueryByExample(typeof(User));

                while (users.HasNext())
                {
                    u = (User)users.Next();
                    if (u.GetUsername() == textBox1.Text && u.GetPassword() == textBox2.Text)
                    {
                        MultimediaDB.sessionUser = u;
                        MultimediaDB.sessionUsername = u.GetUsername();
                        this.Hide();
                        f.Closed += (s, args) => this.Close();
                        f.Show();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Username or Password");
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
