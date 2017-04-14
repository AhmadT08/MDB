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
    public partial class addPerson : Form
    {
        Person newPerson;
        static List<Person> allpeopke;
        public addPerson()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addnewPerson();
            this.Close();
        }


        private void addnewPerson()
        {
            int age = Convert.ToInt32(this.textBox5.Text);
            DateTime DOB = this.dateTimePicker1.Value.Date;
            String ethnicity = this.textBox8.Text;
            FullName fullName = new FullName(this.textBox1.Text, this.textBox4.Text);
            char gender = this.comboBox1.Text.ToArray()[0];
            int height = Convert.ToInt32(this.textBox6.Text);
            string nationality = this.textBox7.Text;
            newPerson = new Person(age, new List<Award>(), new List<Award>(), DOB,
                ethnicity, new List<Feature>(), fullName, gender, height, nationality, new List<User>());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addnewPerson();
            this.textBox1.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
        }
    }
}
