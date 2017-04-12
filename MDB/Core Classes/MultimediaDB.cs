using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;

namespace MDB
{
    static class MultimediaDB
    {
        public static IObjectContainer db;

        static void Main()
        {
            db = Db4oFactory.OpenFile("MDBdraft.yap");
            FullName f = new FullName("Ahmad", "Tajuddin");
            //db.Store(f);
            IObjectSet allstudents = db.QueryByExample(typeof(FullName));
            for (int i = 0; i < allstudents.Count; i++)
            {
                f = (FullName)allstudents[i];
                Console.WriteLine(f.FirstName);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
