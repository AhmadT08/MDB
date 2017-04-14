using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;
using System.Drawing;
using MDB.GUI;

namespace MDB
{
    static class MultimediaDB
    {
        public static IObjectContainer db;
        [STAThread]
        static void Main()
        {
            db = Db4oFactory.OpenFile("../../MDBdraft.yap");
            //try
            //{
            //    Movie f = new Movie(new List<Award>(), new List<Award>(), new List<String>(),
            //                        new List<Person>(), "18+", "IN A WORLD", "Released", 6.6, new List<User>(), "Scary Movie", Image.FromFile(@"..\..\..\Posters\her.jpg"), new DateTime(1996, 6, 6), 121);
            //    Movie a = new Movie(new List<Award>(), new List<Award>(), new List<String>(),
            //                        new List<Person>(), "13+", "WHERE WE FORGET TO ADD A SYNOPSIS", "Released", 8.6, new List<User>(), "Alien", Image.FromFile(@"..\..\..\Posters\her.jpg"), new DateTime(1979, 6, 6), 123);
            //}
            //catch
            //{

            //}
            Movie movieClass = new Movie();

            IObjectSet movie = MDB.MultimediaDB.db.QueryByExample(typeof(Movie));
            while (movie.HasNext())
            {
                movieClass = (Movie)movie.Next();
                Console.WriteLine(movieClass.GetMainCast()[0].GetFeatures()[0].GetEntity().GetTitleName());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
