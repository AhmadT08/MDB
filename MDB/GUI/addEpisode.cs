using System;
using System.Collections;
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
    public partial class addEpisode : Form, addWatchable
    {
        private Show show;
        public static ArrayList mainCast = new ArrayList();

        public addEpisode(int ID)
        {
            InitializeComponent();
            show = MDB.Show.GetShowByID(ID);
        }

        public void addPersonToCast(int personID)
        {
            mainCast.Add(Person.GetPersonByID(personID));
            listBox1.Items.Add(Person.GetPersonByID(personID).GetName().GetFirstName() + " " + Person.GetPersonByID(personID).GetName().GetLastName());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("") || textBox5.Text.Equals("") || textBox2.Text.Equals("") ||
                textBox8.Text.Equals(""))
            {
                MessageBox.Show(@"Please do not leave any fields empty");
            }
            else
            {
                int number = int.Parse(textBox6.Text);
                int season = int.Parse(textBox5.Text);
                string title = textBox2.Text;
                double rating = double.Parse(textBox8.Text);
                List<Person> cast = mainCast.Cast<Person>().ToList();
                Episode newEpisode = new Episode(number, season, title, cast, rating, show);
                show.AddEpisode(newEpisode);
                MessageBox.Show(@"Episode successfully created");
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addPerson newPerson = new addPerson(true, this);
            newPerson.ShowDialog();
        }
    }
}
