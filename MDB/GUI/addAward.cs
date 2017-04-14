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
        Boolean won;
        addMovie movie = new addMovie();
        public addAward()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox5.Text == "none")
            {

            }
            else
            {
                int year = Convert.ToInt32(this.comboBox4.Text);
                String category = this.textBox6.Text;
                String title = this.textBox5.Text;
                if (this.comboBox3.Text.Equals("Yes"))
                {
                    won = true;
                    Award newAward = new Award(year, category, title, won, new Watchable());
                    addMovie.wonAward.Add(newAward);

                }
                else if (this.comboBox3.Text.Equals("No"))
                {
                    won = false;
                    Award newAward = new Award(year, category, title, won, new Watchable());
                    addMovie.nomAward.Add(newAward);
                }
                this.listBox2.Items.Add(this.textBox5.Text);
                this.textBox5.Text = "";
                this.textBox6.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
