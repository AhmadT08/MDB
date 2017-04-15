using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Db4objects.Db4o;

namespace MDB.GUI
{
    public partial class ShowMovie : Form
    {
        public ShowMovie()
        {
            InitializeComponent();

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
            Movie m = Movie.GetMovieByTitle("Her");
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
