using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MDB.Core_Classes;

namespace MDB.GUI
{
    public partial class ShowMovie : Form
    {
        public ShowMovie()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowMovie_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            FullName ana = new FullName("Ahmed", "hisham");
            DateTime dateOfBirth = new DateTime();
            List<User> us = new List<User>();
            User u = new User("qweewq", "TOMNAZ1", new List<Watchable>(), new List<Watchable>(), ana, dateOfBirth, "boss_tomna@hotmail.com", new List<Watchable>(), new List<Person>());
            us.Add(u);
            //u.SetWatchableSubscriptions(new List<Watchable>());
            Movie m = Movie;
            f.AddSubscriber(u);
            f.Notify();
        }
    }
}
