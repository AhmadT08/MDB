using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;

namespace MDB.GUI
{
    public partial class addShow : Form, addWatchable
    {
        //        ArrayList allAwards = new ArrayList();
        //        public static List<String> castNames = new List<String>();
        public static ArrayList mainCast = new ArrayList();
        Image posterImage;

        public addShow()
        {
            InitializeComponent();
        }

        public void addPersonToCast(int personID)
        {
            mainCast.Add(Person.GetPersonByID(personID));
            listBox1.Items.Add(Person.GetPersonByID(personID).GetName().GetFirstName() + " " + Person.GetPersonByID(personID).GetName().GetLastName());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addPerson newPerson = new addPerson(true, this);
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
            List<string> genre = checkedListBox1.CheckedItems.OfType<string>().ToList();
            List<Person> person = mainCast.Cast<Person>().ToList();
            string MPAA = comboBox1.Text;
            string synopsis = richTextBox1.Text;
            string production = comboBox2.Text;
            int rating = Convert.ToInt32(textBox2.Text);
            string title = textBox1.Text;
            DateTime pilot = dateTimePicker1.Value.Date;
            int seasons = Convert.ToInt32(textBox3.Text);
            if (!MDB.Show.Exists(textBox1.Text))
            {
                Show newShow = new Show(new List<Award>(), new List<Award>(), genre, person,
                    MPAA, synopsis, production, rating, new List<User>(), title, posterImage, seasons, 0, pilot,
                    new List<Episode>());
                MessageBox.Show(@"Show successfully added");
                //Adding 'Watchable' and 'Person' back into 'Feature'
                for (int i = 0; i < newShow.GetMainCast().Count; i++)
                {
                    List<Feature> op = newShow.GetMainCast()[i].GetFeatures();
                    op[op.Count - 1].SetEntity(newShow);
                    op[op.Count - 1].SetPerson(newShow.GetMainCast()[i]);
                }
            }
            else
            {
                Show newShow = MDB.Show.GetShowByTitle(title);
                newShow.SetGenre(genre);
                newShow.SetMainCast(person);
                newShow.SetMpaaRating(MPAA);
                newShow.SetSynopsis(synopsis);
                newShow.SetProductionStatus(production);
                newShow.SetRating(rating);
                newShow.SetPilotDate(pilot);
                newShow.SetSeasons(seasons);
                newShow.setPoster(posterImage);

                MessageBox.Show(@"Show successfully edited");
                //Adding 'Watchable' and 'Person' back into 'Feature'
                for (int i = 0; i < newShow.GetMainCast().Count; i++)
                {
                    List<Feature> op = newShow.GetMainCast()[i].GetFeatures();
                    op[op.Count - 1].SetEntity(newShow);
                    op[op.Count - 1].SetPerson(newShow.GetMainCast()[i]);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Show x = new Show();
            string title = textBox1.Text;
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            if (!MDB.Show.Exists(textBox1.Text))
            {
                MessageBox.Show(@"Show does not exist in the database");
                ClearAll();
            }
            else
            {
                for (int i = 0; i < AllObjects.Count; i++)
                {
                    x = (Show)AllObjects[i];
                    if (x.GetTitleName().Equals(title))
                    {
                        Lookup(x);
                    }
                }
            }
        }

        private void CheckBoxLookup(Show show)
        {
            for (int j = 0; j < checkedListBox1.Items.Count; j++) //clears check box
            {
                checkedListBox1.SetItemChecked(j, false);
            }

            for (int i = 0; i < show.GetGenre().Count; i++)
            {
                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    if (show.GetGenre()[i].Equals(checkedListBox1.Items[j].ToString()))
                    {
                        checkedListBox1.SetItemChecked(j, true); //check matching genre
                    }
                }
            }
        }

        private void FillCastNames(Show show)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < show.GetMainCast().Count; i++)
            {
                listBox1.Items.Add(show.GetMainCast()[i].GetName().GetFirstName() + " " +
                                   show.GetMainCast()[i].GetName().GetLastName());
            }
        }

        private void Lookup(Show x)
        {
            CheckBoxLookup(x);
            FillCastNames(x);
            comboBox1.Text = x.GetMpaaRating();
            richTextBox1.Text = x.GetSynopsis();
            comboBox2.Text = x.GetProductionStatus();
            textBox2.Text = x.GetRating().ToString();
            textBox1.Text = x.GetTitleName();
            dateTimePicker1.Value = x.GetPilotDate();
            textBox3.Text = x.GetSeasons().ToString();
            posterImage = pictureBox1.Image = x.getPoster();
        }

        private void ClearAll()
        {
            for (int j = 0; j < checkedListBox1.Items.Count; j++) //clears check box
            {
                checkedListBox1.SetItemChecked(j, false);
            }
            listBox1.Items.Clear();
            comboBox1.Text = "";
            richTextBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!MDB.Show.Exists(textBox1.Text))
            {
                MessageBox.Show(@"Show does not exist in the database");
            }
            else
            {
                addEpisode ep = new addEpisode(MDB.Show.GetShowByTitle(textBox1.Text).GetID());
            }
        }
    }
}
