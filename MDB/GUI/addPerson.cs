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
    public partial class addPerson : Form
    {
        Person newPerson;
        string acting;
        string production;
        bool _referred;
        addWatchable _referrer;

        public addPerson(bool referred, addWatchable referrer)
        //        public addPerson()
        {
            InitializeComponent();
            _referred = referred;
            _referrer = referrer;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addNewPerson();
            Close();
        }


        private void addNewPerson()
        {
            int age = Convert.ToInt32(textBox5.Text);
            DateTime DOB = dateTimePicker1.Value.Date;
            string ethnicity = textBox8.Text;
            FullName fullName = new FullName(textBox1.Text, textBox4.Text);
            char gender = comboBox1.Text.ToArray()[0];
            int height = Convert.ToInt32(textBox6.Text);
            string nationality = textBox7.Text;
            List<Feature> allFeatures = new List<Feature>();
            if (comboBox2.Text == "Acting")
            {
                acting = textBox2.Text;
                production = "none";
            }
            else if (comboBox2.Text == "Production")
            {
                acting = "none";
                production = textBox2.Text;
            }
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));
            Feature feature = new Feature(acting, new Watchable(), new Person(), production);
            allFeatures.Add(feature);
            if (Person.Exists(fullName, age))
            {
                newPerson = Person.GetPersonByNameAge(fullName, age);
                newPerson.AddFeature(feature);
            }
            else
            {
                newPerson = new Person(age, new List<Award>(), new List<Award>(), DOB,
                ethnicity, allFeatures, fullName, gender, height, nationality, new List<User>());
            }

            if (_referred)
            {
                _referrer.addPersonToCast(newPerson.GetID());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNewPerson();
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
