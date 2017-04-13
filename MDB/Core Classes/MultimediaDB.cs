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
            db = Db4oFactory.OpenFile("MDBdraft1.yap");
            Movie f = new Movie(new List<Award>(), new List<Award>(), new List<String>(),
                                new List<Person>(), "18+", "Released", 6.6, new List<User>(), "Scary Movie", new DateTime(1996, 6, 6), 121);

            IObjectSet allstudents = db.QueryByExample(typeof(Movie));
            for (int i = 0; i < allstudents.Count; i++)
            {
                f = (Movie)allstudents[i];
                Console.WriteLine(i + " " + f.GetRating());
            }
            Console.WriteLine("\n");
            f.SetRating(5.5);

            allstudents = db.QueryByExample(typeof(Movie));
            for (int i = 0; i < allstudents.Count; i++)
            {
                f = (Movie)allstudents[i];
                Console.WriteLine(i + " " + f.GetRating());
            }
            Console.WriteLine("\n");

            f.Delete();

            allstudents = db.QueryByExample(typeof(Award));
            for (int i = 0; i < allstudents.Count; i++)
            {
                f = (Movie)allstudents[i];
                Console.WriteLine(i + " " + f.GetRating());
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
