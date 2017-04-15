using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MDB.GUI;

namespace MDB
{
    public partial class Form1 : Form
    {
        int moviePictureBoxCounter = 1;
        int moviePicturePosition = 4;
        int movieTitlePosition = 7;
        int showPictureBoxCounter = 1;
        int showPicturePosition = 4;
        int showTitlePosition = 7;
        public static IObjectContainer db;
        public Form1()
        {
            InitializeComponent();
            initalizeMovies();
            Console.WriteLine(MultimediaDB.sessionUser);
            if (MultimediaDB.sessionUsername == "admin")
            {
                adminControl.Visible = true;
            }
        }


        private void createPictureBoxandTitle(int id, Image poster, String title, String type)
        {
            Panel panel = new Panel();
            panel.Size = new Size(150, 220);
            panel.BackColor = Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));

            PictureBox picturebox = new PictureBox();
            picturebox.MaximumSize = new Size(145, 215);
            picturebox.Location = new Point(2, 2);
            picturebox.Size = new Size(145, 215);
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Image = poster;
            picturebox.TabStop = false;
            picturebox.MouseHover += new EventHandler(picturebox_MouseHover);
            picturebox.MouseLeave += new EventHandler(picturebox_MouseLeave);
            picturebox.Click += new EventHandler(picturebox_Click);

            Label ItemTitle = new Label();
            ItemTitle.AutoSize = true;
            ItemTitle.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ItemTitle.ForeColor = Color.White;
            ItemTitle.MaximumSize = new Size(145, 0);
            ItemTitle.MinimumSize = new Size(145, 0);
            ItemTitle.Size = new Size(145, 23);
            ItemTitle.TabIndex = 1;
            ItemTitle.Text = title;
            ItemTitle.TextAlign = ContentAlignment.TopCenter;
            if (type == "Movie")
            {
                panel.Location = new Point(moviePicturePosition, 3);
                panel.Name = "WrappermovieBox" + moviePictureBoxCounter;
                picturebox.Name = "movie-" + id;
                picturebox.TabIndex = moviePictureBoxCounter;
                ItemTitle.Location = new Point(movieTitlePosition, 218);
                ItemTitle.Name = "mLabel" + moviePictureBoxCounter;
                panel.Controls.Add(picturebox);
                panel14.Controls.Add(panel);
                panel14.Controls.Add(ItemTitle);
                moviePictureBoxCounter++;
                moviePicturePosition += 156;
                movieTitlePosition += 152;
            }
            else if (type == "Show")
            {
                panel.Location = new Point(showPicturePosition, 3);
                panel.Name = "WrappershowBox" + moviePictureBoxCounter;
                picturebox.Name = "show-" + id;
                picturebox.TabIndex = showPictureBoxCounter;
                ItemTitle.Location = new Point(showTitlePosition, 218);
                ItemTitle.Name = "sLabel" + showPictureBoxCounter;
                panel.Controls.Add(picturebox);
                panel2.Controls.Add(panel);
                panel2.Controls.Add(ItemTitle);
                showPictureBoxCounter++;
                showPicturePosition += 156;
                showTitlePosition += 152;
            }
        }

        private void picturebox_Click(object sender, EventArgs e)
        {
            PictureBox op = (PictureBox)sender;
            String[] lo = op.Name.Split('-');
            //            Console.WriteLine(lo[0] + "-" + lo[1]);
            ShowMovie showMovie = new ShowMovie(Convert.ToInt32(lo[1]), lo[0]);
            showMovie.ShowDialog();
        }

        private void picturebox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox op = (PictureBox)sender;
            op.Parent.BackColor = Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
        }

        private void picturebox_MouseHover(object sender, EventArgs e)
        {
            PictureBox op = (PictureBox)sender;
            op.Parent.BackColor = Color.Yellow;
        }

        private void AddToPanel(PictureBox picturebox, Label ItemTitle)
        {

        }
        public void initalizeMovies()
        {
            Movie movieClass = new Movie();
            Show showClass = new Show();
            IObjectSet movie = MultimediaDB.db.QueryByExample(typeof(Movie));
            IObjectSet show = MultimediaDB.db.QueryByExample(typeof(Show));
            while (movie.HasNext())
            {
                movieClass = (Movie)movie.Next();
                createPictureBoxandTitle(movieClass.GetID(), (Image)movieClass.getPoster(), movieClass.GetTitleName(), "Movie");
            }
            while (show.HasNext())
            {
                showClass = (Show)show.Next();
                createPictureBoxandTitle(showClass.GetID(), (Image)showClass.getPoster(), showClass.GetTitleName(), "Show");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addMovie movieWindow = new addMovie();
            movieWindow.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addShow showWindow = new addShow();
            showWindow.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Notification notify = new Notification();
            notify.ShowDialog();
        }
    }
}
