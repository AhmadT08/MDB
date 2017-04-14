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
        public addAward()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.comboBox3.Text.Equals("Yes"))
            {
                won = true;
            }
            else if (this.comboBox3.Text.Equals("No"))
            {
                won = false;
            }
            this.listBox2.Items.Add(this.textBox5.Text);
            this.textBox5.Text = "";

        }
    }
}
