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
        int moviePictureBoxCounter = 1;
        int moviePicturePosition = 4;
        int movieTitlePosition = 7;
        int showPictureBoxCounter = 1;
        int showPicturePosition = 4;
        int showTitlePosition = 7;

        public ShowMovie(int ID, string type)
        {
            InitializeComponent();
            _ID = ID;
            _Watchabletype = type;
            if (MultimediaDB.sessionUsername == "admin")
            {
                adminControl.Visible = true;
                userControls.Visible = false;
            }
            else
            {
                adminControl.Visible = false;
                userControls.Visible = true;
            }
            initializeData();
            GenerateSuggestions();
        }

        private void initializeData()
        {
            if (_Watchabletype == "movie")
            {
                Movie watchable = Movie.GetMovieByID(_ID);
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
                label6.Text = "Similar Movies";
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
                Show watchable = MDB.Show.GetShowByID(_ID);
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
                label6.Text = "Similar Shows";
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
            if (Movie.Exists(_ID))
            {
                Movie m = Movie.GetMovieByID(_ID);
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
            else if (MDB.Show.Exists(_ID))
            {
                Show m = MDB.Show.GetShowByID(_ID);
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Movie.Exists(_ID))
            {
                Movie m = Movie.GetMovieByID(_ID);
                if (MultimediaDB.sessionUser.GetWatchableSubscriptions().Contains(m))
                {
                    MultimediaDB.sessionUser.UnsubscribeToWatchable(m);
                    MessageBox.Show("Successfully unsubscribed to " + m.GetTitleName());
                    Console.WriteLine(m.GetMatchingObject().GetSubscribers().Count);
                    button3.Text = "Subscribe";
                }
                else
                {
                    MultimediaDB.sessionUser.SubscribeToWatchable(m);
                    MessageBox.Show("Successfully subscribed to " + m.GetTitleName());
                    Console.WriteLine(m.GetMatchingObject().GetSubscribers().Count);
                    button3.Text = "Unsubscribe";
                }
            }
            else if (MDB.Show.Exists(_ID))
            {
                Show m = MDB.Show.GetShowByID(_ID);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Movie.Exists(_ID))
            {
                Movie m = Movie.GetMovieByID(_ID);
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
            else if
                (MDB.Show.Exists(_ID))
            {
                Show m = MDB.Show.GetShowByID(_ID);
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

        public void GenerateSuggestions()
        {
            if (_Watchabletype.Equals("movie"))
            {
                IList<Movie> result = MultimediaDB.db.Query<Movie>(delegate (Movie m)
                {
                    return m.GetGenre().Contains(Movie.GetMovieByID(_ID).GetGenre()[0]) || m.GetGenre().Contains(Movie.GetMovieByID(_ID).GetGenre()[1]);
                });
                Console.WriteLine(result.Count);
                foreach (Movie m in result)
                {
                    if (m.GetTitleName().Equals(Movie.GetMovieByID(_ID).GetTitleName()))
                    {
                        //do nothing
                    }
                    else
                    {
                        PictureBox picturebox = new PictureBox();
                        picturebox.MaximumSize = new Size(145, 215);
                        picturebox.Location = new Point(2, 2);
                        picturebox.Size = new Size(145, 215);
                        picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                        picturebox.Image = m.getPoster();
                        picturebox.TabStop = false;

                        Label ItemTitle = new Label();
                        ItemTitle.AutoSize = true;
                        ItemTitle.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        ItemTitle.ForeColor = Color.White;
                        ItemTitle.MaximumSize = new Size(145, 0);
                        ItemTitle.MinimumSize = new Size(145, 0);
                        ItemTitle.Size = new Size(145, 23);
                        ItemTitle.TabIndex = 1;
                        ItemTitle.Text = m.GetTitleName();
                        ItemTitle.TextAlign = ContentAlignment.TopCenter;

                        picturebox.Name = "movie-" + m.GetID();
                        picturebox.TabIndex = moviePictureBoxCounter;
                        picturebox.Location = new Point(moviePicturePosition, 460);
                        ItemTitle.Location = new Point(movieTitlePosition, 218);
                        ItemTitle.Name = "mLabel" + moviePictureBoxCounter;
                        this.Controls.Add(picturebox);
                        this.Controls.Add(ItemTitle);
                        moviePictureBoxCounter++;
                        moviePicturePosition += 156;
                        movieTitlePosition += 152;
                    }
                }
            }
            else
            {
                IList<Show> result = MultimediaDB.db.Query<Show>(delegate (Show m)
                {
                    return m.GetGenre().Contains(MDB.Show.GetShowByID(_ID).GetGenre()[0]) || m.GetGenre().Contains(MDB.Show.GetShowByID(_ID).GetGenre()[1]);
                });
                Console.WriteLine(result.Count);
                foreach (Show m in result)
                {
                    if (m.GetTitleName().Equals(MDB.Show.GetShowByID(_ID).GetTitleName()))
                    {
                        //do nothing
                    }
                    else
                    {
                        PictureBox picturebox = new PictureBox();
                        picturebox.MaximumSize = new Size(145, 215);
                        picturebox.Location = new Point(2, 2);
                        picturebox.Size = new Size(145, 215);
                        picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                        picturebox.Image = m.getPoster();
                        picturebox.TabStop = false;

                        Label ItemTitle = new Label();
                        ItemTitle.AutoSize = true;
                        ItemTitle.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        ItemTitle.ForeColor = Color.White;
                        ItemTitle.MaximumSize = new Size(145, 0);
                        ItemTitle.MinimumSize = new Size(145, 0);
                        ItemTitle.Size = new Size(145, 23);
                        ItemTitle.TabIndex = 1;
                        ItemTitle.Text = m.GetTitleName();
                        ItemTitle.TextAlign = ContentAlignment.TopCenter;

                        picturebox.Name = "Show-" + m.GetID();
                        picturebox.TabIndex = moviePictureBoxCounter;
                        picturebox.Location = new Point(moviePicturePosition, 460);
                        ItemTitle.Location = new Point(movieTitlePosition, 218);
                        ItemTitle.Name = "mLabel" + moviePictureBoxCounter;
                        this.Controls.Add(picturebox);
                        this.Controls.Add(ItemTitle);
                        moviePictureBoxCounter++;
                        moviePicturePosition += 156;
                        movieTitlePosition += 152;
                    }
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }

}