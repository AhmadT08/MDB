using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Db4objects.Db4o;

namespace MDB.GUI
{
    public partial class addMovie : Form
    {
        ArrayList allAwards = new ArrayList();
        public static List<String> castNames = new List<String>();
        public static ArrayList mainCast = new ArrayList();
        Boolean won;
        Image posterImage;
        public addMovie()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            addPerson newPerson = new addPerson();
            newPerson.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = this.openFileDialog1.FileName;
                posterImage = new Bitmap(this.openFileDialog1.FileName);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<String> genre = this.checkedListBox1.CheckedItems.OfType<String>().ToList();
            List<Person> person = mainCast.Cast<Person>().ToList();
            String MPAA = this.comboBox1.Text;
            String synopsis = this.richTextBox1.Text;
            String production = this.comboBox2.Text;
            int rating = Convert.ToInt32(this.textBox2.Text);
            String title = this.textBox1.Text;
            DateTime released = this.dateTimePicker1.Value.Date;
            int time = Convert.ToInt32(this.textBox3.Text);
            Movie newMovie = new Movie(new List<Award>(), new List<Award>(), genre, person,
                MPAA, synopsis, production, rating, new List<User>(), title, posterImage, released, time);

            //Adding 'Watchable' and 'Person' back into 'Feature'
            for (int i = 0; i < newMovie.GetMainCast().Count; i++)
            {
                List<Feature> op = newMovie.GetMainCast()[i].GetFeatures();
                op[op.Count - 1].SetEntity(newMovie);
                op[op.Count - 1].SetPerson(newMovie.GetMainCast()[i]);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
