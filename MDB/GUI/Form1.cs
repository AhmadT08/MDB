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
        PictureBox picturebox;
        Label movieLabel;
        int pictureBoxCounter = 1;
        int picturePosition = 4;
        int titlePosition = 7;
        public static IObjectContainer db;
        public Form1()
        {
            InitializeComponent();
            initalizeMovies();
        }

        private void createPictureBoxandTitle(Movie mov)
        {
            picturebox = new PictureBox();
            picturebox.Location = new Point(picturePosition, 0);
            picturebox.MaximumSize = new Size(145, 215);
            picturebox.Name = "pictureBox" + pictureBoxCounter;
            picturebox.Size = new Size(145, 215);
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.TabIndex = pictureBoxCounter;
            try
            {
                picturebox.Image = (Image)mov.getPoster();
            }
            catch
            {

            }
            picturebox.TabStop = false;

            movieLabel = new Label();
            movieLabel.AutoSize = true;
            movieLabel.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            movieLabel.ForeColor = Color.White;
            movieLabel.Location = new Point(titlePosition, 218);
            movieLabel.MaximumSize = new Size(145, 0);
            movieLabel.MinimumSize = new Size(145, 0);
            movieLabel.Name = "mLabel" + pictureBoxCounter;
            movieLabel.Size = new Size(145, 23);
            movieLabel.TabIndex = 1;
            movieLabel.Text = mov.GetTitleName();
            movieLabel.TextAlign = ContentAlignment.TopCenter;

            panel14.Controls.Add(picturebox);
            panel14.Controls.Add(movieLabel);
            pictureBoxCounter++;
            picturePosition += 156;
            titlePosition += 152;
        }

        public void initalizeMovies()
        {
            Movie movieClass = new Movie();
            IObjectSet movie = MultimediaDB.db.QueryByExample(typeof(Movie));
            while (movie.HasNext())
            {
                movieClass = (Movie)movie.Next();
                createPictureBoxandTitle(movieClass);
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
