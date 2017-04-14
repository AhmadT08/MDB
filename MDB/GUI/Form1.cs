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
            db = Db4oFactory.OpenFile("MDBdraft.yap");
            InitializeComponent();
            initalizeMovies();
        }

        private void createPictureBoxandTitle(MDB.Movie mov)
        {
            picturebox = new System.Windows.Forms.PictureBox();
            picturebox.Location = new System.Drawing.Point(picturePosition, 0);
            picturebox.MaximumSize = new System.Drawing.Size(145, 215);
            picturebox.Name = "pictureBox" + pictureBoxCounter;
            picturebox.Size = new System.Drawing.Size(145, 215);
            picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picturebox.TabIndex = pictureBoxCounter;
            try
            {
                picturebox.Image = (Image)mov.getPoster();
            }
            catch
            {

            }
            picturebox.TabStop = false;

            movieLabel = new System.Windows.Forms.Label();
            movieLabel.AutoSize = true;
            movieLabel.Font = new System.Drawing.Font("Gill Sans MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            movieLabel.ForeColor = System.Drawing.Color.White;
            movieLabel.Location = new System.Drawing.Point(titlePosition, 218);
            movieLabel.MaximumSize = new System.Drawing.Size(145, 0);
            movieLabel.MinimumSize = new System.Drawing.Size(145, 0);
            movieLabel.Name = "mLabel" + pictureBoxCounter;
            movieLabel.Size = new System.Drawing.Size(145, 23);
            movieLabel.TabIndex = 1;
            movieLabel.Text = mov.GetTitleName();
            movieLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.panel14.Controls.Add(picturebox);
            this.panel14.Controls.Add(movieLabel);
            pictureBoxCounter++;
            picturePosition += 156;
            titlePosition += 152;
        }

        public void initalizeMovies()
        {
            Movie movieClass = new Movie();
            IObjectSet movie = db.QueryByExample(typeof(Movie));
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
