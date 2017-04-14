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

namespace MDB.GUI
{
    public partial class addMovie : Form
    {
        ArrayList allAwards = new ArrayList();
        public static List<String> castNames = new List<String>();
        public static ArrayList mainCast = new ArrayList();
        Boolean won;
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
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine(mainCast[0]);
            //List<String> o = this.checkedListBox1.CheckedItems.OfType<String>().ToList();
            //Movie f = new Movie(new List<Award>(), new List<Award>(), new List<String>(),
            //                    new List<Person>(), "18+", "IN A WORLD", "Released", 6.6, new List<User>(),
            //                    "Scary Movie", Image.FromFile(@"..\..\..\Posters\her.jpg"),
            //                    new DateTime(1996, 6, 6), 121);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
