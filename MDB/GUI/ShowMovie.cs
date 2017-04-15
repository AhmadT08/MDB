using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Db4objects.Db4o;
using System.Drawing;

namespace MDB.GUI
{
    public partial class ShowMovie : Form
    {
        int _ID;
        string _Watchabletype;

        public ShowMovie(int ID, string type)
        {
            InitializeComponent();
            _ID = ID;
            _Watchabletype = type;
            initializeData();
        }

        private void initializeData()
        {
            if (_Watchabletype == "movie")
            {
                MDB.Movie watchable = MDB.Movie.GetMovieByID(_ID);
                pictureBox1.Image = (Image)watchable.getPoster();
                label1.Text = watchable.GetTitleName();
                label2.Text = watchable.GetReleaseDate().Year.ToString();
                label3.Text = watchable.GetRunTime() + "min";
                label4.Text = "";
                for (int i = 0; i < watchable.GetGenre().Count; i++)
                {
                    if (i == watchable.GetGenre().Count - 1)
                    {
                        label4.Text += watchable.GetGenre()[i];
                    }
                    else
                    {
                        label4.Text += watchable.GetGenre()[i] + "/";
                    }
                }
                label5.Text = watchable.GetRating() + "%";
                richTextBox1.Text = watchable.GetSynopsis();
                //                Console.WriteLine(MultimediaDB.sessionUser.GetWatchableSubscriptions().Count);
                //                List<Watchable> x = MultimediaDB.sessionUser.GetWatchableSubscriptions();
                if (MultimediaDB.sessionUser.GetWatchableSubscriptions().Contains(watchable))
                {
                    button3.Text = "Unsubscribe";
                }
                else
                {
                    button3.Text = "Subscribe";
                }
            }
            else
            {
                MDB.Show watchable = MDB.Show.GetShowByID(_ID);
                pictureBox1.Image = (Image)watchable.getPoster();
                label1.Text = watchable.GetTitleName();
                label2.Text = watchable.GetPilotDate().Year.ToString();
                label3.Text = watchable.GetSeasons() + " seasons";
                label4.Text = "";
                for (int i = 0; i < watchable.GetGenre().Count; i++)
                {
                    if (i == watchable.GetGenre().Count - 1)
                    {
                        label4.Text += watchable.GetGenre()[i];
                    }
                    else
                    {
                        label4.Text += watchable.GetGenre()[i] + "/";
                    }
                }
                label5.Text = watchable.GetRating() + "%";
                richTextBox1.Text = watchable.GetSynopsis();

                if (MultimediaDB.sessionUser.GetWatchableSubscriptions().Contains(watchable))
                {
                    button3.Text = "Unsubscribe";
                }
                else
                {
                    button3.Text = "Subscribe";
                }
            }
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
            MDB.Movie m = MDB.Movie.GetMovieByTitle("Birdman");

            MultimediaDB.sessionUser.SubscribeToWatchable(m);

        }
    }
}
