using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDB.GUI
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FullName fname = new FullName(textBox1.Text, textBox2.Text);
            User u = new User(textBox4.Text, textBox3.Text, new List<Watchable>(), new List<Watchable>(), fname, dateTimePicker1.Value.Date,textBox5.Text,new List<Watchable>(),new List<Person>());
            User.Update(u); 
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
