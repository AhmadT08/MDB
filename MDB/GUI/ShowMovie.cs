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
                MDB.Movie show = MDB.Movie.GetMovieByID(_ID);
                pictureBox1.Image = (Image)show.getPoster();
                label1.Text = show.GetTitleName();

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
            u.SubscribeToWatchable(m);

            User movieClass = new User();
            IObjectSet movie = MDB.MultimediaDB.db.QueryByExample(typeof(User));
            while (movie.HasNext())
            {
                movieClass = (User)movie.Next();
                Console.WriteLine(movieClass.GetWatchableSubscriptions().Count);
            }
        }
    }
}
