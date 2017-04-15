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
    public partial class addAward : Form
    {
        bool won;
        addMovie movie = new addMovie();
        public addAward()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "none")
            {

            }
            else
            {
                int year = Convert.ToInt32(comboBox4.Text);
                string category = textBox6.Text;
                string title = textBox5.Text;
                if (comboBox3.Text.Equals("Yes"))
                {
                    won = true;
                    Award newAward = new Award(year, category, title, won, new Watchable());
                    addMovie.wonAward.Add(newAward);

                }
                else if (comboBox3.Text.Equals("No"))
                {
                    won = false;
                    Award newAward = new Award(year, category, title, won, new Watchable());
                    addMovie.nomAward.Add(newAward);
                }
                listBox2.Items.Add(textBox5.Text);
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
