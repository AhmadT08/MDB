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

                if (MultimediaDB.sessionUser.GetWatchableSubscriptions().Contains(watchable))
                {
                    button3.Text = "Unsubscribe";
                }
                else
                {
                    button3.Text = "Subscribe";
                }

                if (MultimediaDB.sessionUser.GetWatchList().Contains(watchable))
                {
                    button1.Text = "Remove From Watchlist";
                }
                else
                {
                    button1.Text = "Add To Watchlist";
                }

                if (MultimediaDB.sessionUser.GetWatched().Contains(watchable))
                {
                    button2.Text = "Watched";
                }
                else
                {
                    button2.Text = "Not Watched";
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

                if (MultimediaDB.sessionUser.GetWatchList().Contains(watchable))
                {
                    button1.Text = "Remove From Watchlist";
                }
                else
                {
                    button1.Text = "Add To Watchlist";
                }

                if (MultimediaDB.sessionUser.GetWatched().Contains(watchable))
                {
                    button2.Text = "Watched";
                }
                else
                {
                    button2.Text = "Not Watched";
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
            MDB.Movie m = MDB.Movie.GetMovieByID(_ID);
            if (!MultimediaDB.sessionUser.GetWatchList().Contains(m))
            {
                MultimediaDB.sessionUser.AddToWatchList(m);
                button1.Text = "Remove From Watchlist";
            }
            else
            {
                MultimediaDB.sessionUser.RemoveFromWatchList(m);
                button1.Text = "Add To Watchlist";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MDB.Movie m = MDB.Movie.GetMovieByID(_ID);
            if (MultimediaDB.sessionUser.GetWatchableSubscriptions().Contains(m))
            {
                MultimediaDB.sessionUser.UnsubscribeToWatchable(m);
                MessageBox.Show("Successfully unsubscribed to " + m.GetTitleName());
                Console.WriteLine(m.GetSubscribers().Count);
                button3.Text = "Subscribe";
            }
            else
            {
                MultimediaDB.sessionUser.SubscribeToWatchable(m);
                MessageBox.Show("Successfully subscribed to " + m.GetTitleName());
                Console.WriteLine(m.GetSubscribers().Count);
                button3.Text = "Unsubscribe";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MDB.Movie m = MDB.Movie.GetMovieByID(_ID);
            if (!MultimediaDB.sessionUser.GetWatched().Contains(m))
            {
                MultimediaDB.sessionUser.AddToWatched(m);
                button2.Text = "Watched";
            }
            else
            {
                MultimediaDB.sessionUser.RemoveFromWatched(m);
                button2.Text = "Not Watched";
            }
        }
    }
}
