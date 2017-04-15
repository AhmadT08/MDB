using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDB.GUI
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
            for (int i = 0; i < MultimediaDB.sessionUser.GetNotifications().Count; i++)
            {
                listBox1.Items.Add(MultimediaDB.sessionUser.GetNotifications()[i]);
            }
        }
    }
}
