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
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Username = textBox1.Text;
            String password = textBox2.Text;
            User u = new User();

            IObjectSet users = MDB.MultimediaDB.db.QueryByExample(typeof(User));
            while (users.HasNext())
            {
                u = (User)users.Next();
                Console.WriteLine(u.ge()[0].GetTitle());
            }
        }
    }
}
