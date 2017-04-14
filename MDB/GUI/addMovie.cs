using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Db4objects.Db4o;

namespace MDB.GUI
{
    public partial class addMovie : Form
    {
        ArrayList allAwards = new ArrayList();
        public static List<String> castNames = new List<String>();
        public static ArrayList wonAward = new ArrayList();
        public static ArrayList nomAward = new ArrayList();
        public static ArrayList mainCast = new ArrayList();
        Boolean won;
        Image posterImage;
        public addMovie()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            addPerson newPerson = new addPerson();
            newPerson.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                posterImage = new Bitmap(openFileDialog1.FileName);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<String> genre = checkedListBox1.CheckedItems.OfType<String>().ToList();
            List<Person> person = mainCast.Cast<Person>().ToList();
            List<Award> nominated = nomAward.Cast<Award>().ToList();
            List<Award> won = wonAward.Cast<Award>().ToList();
            String MPAA = comboBox1.Text;
            String synopsis = richTextBox1.Text;
            String production = comboBox2.Text;
            int rating = Convert.ToInt32(textBox2.Text);
            String title = textBox1.Text;
            DateTime released = dateTimePicker1.Value.Date;
            int time = Convert.ToInt32(textBox3.Text);
            Movie newMovie = new Movie(nominated, won, genre, person,
                MPAA, synopsis, production, rating, new List<User>(), title, posterImage, released, time);

            //Adding 'Watchable' and 'Person' back into 'Feature'
            for (int i = 0; i < newMovie.GetMainCast().Count; i++)
            {
                List<Feature> op = newMovie.GetMainCast()[i].GetFeatures();
                op[op.Count - 1].SetEntity(newMovie);
                op[op.Count - 1].SetPerson(newMovie.GetMainCast()[i]);
            }

            //Adding 'Watchable' to AwardNominations and AwardWins
            for (int j = 0; j < newMovie.GetAwardNominations().Count; j++)
            {
                newMovie.GetAwardNominations()[j].SetWatchable(newMovie);
            }
            for (int j = 0; j < newMovie.GetAwardWins().Count; j++)
            {
                newMovie.GetAwardWins()[j].SetWatchable(newMovie);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addAward newPerson = new addAward();
            newPerson.ShowDialog();
        }
    }
}
