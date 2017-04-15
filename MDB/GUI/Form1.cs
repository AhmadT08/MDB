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
        }

        private void createPictureBoxandTitle(Image poster, String title, String type)
        {
            PictureBox picturebox = new PictureBox();
            picturebox.MaximumSize = new Size(145, 215);
            picturebox.Size = new Size(145, 215);
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Image = poster;
            picturebox.TabStop = false;

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
                picturebox.Location = new Point(moviePicturePosition, 0);
                picturebox.Name = "movieBox" + moviePictureBoxCounter;
                picturebox.TabIndex = moviePictureBoxCounter;
                ItemTitle.Location = new Point(movieTitlePosition, 218);
                ItemTitle.Name = "mLabel" + moviePictureBoxCounter;
                panel14.Controls.Add(picturebox);
                panel14.Controls.Add(ItemTitle);
                moviePictureBoxCounter++;
                moviePicturePosition += 156;
                movieTitlePosition += 152;
            }
            else if (type == "Show")
            {
                picturebox.Location = new Point(showPicturePosition, 0);
                picturebox.Name = "movieBox" + showPictureBoxCounter;
                picturebox.TabIndex = showPictureBoxCounter;
                ItemTitle.Location = new Point(showTitlePosition, 218);
                ItemTitle.Name = "mLabel" + showPictureBoxCounter;
                panel2.Controls.Add(picturebox);
                panel2.Controls.Add(ItemTitle);
                showPictureBoxCounter++;
                showPicturePosition += 156;
                showTitlePosition += 152;
            }
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
                createPictureBoxandTitle((Image)movieClass.getPoster(), movieClass.GetTitleName(), "Movie");
            }
            while (show.HasNext())
            {
                showClass = (Show)show.Next();
                createPictureBoxandTitle((Image)showClass.getPoster(), showClass.GetTitleName(), "Show");
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
    }
}
