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
        public static User sessionUser;
        public static String sessionUsername;
        [STAThread]
        static void Main()
        {
            db = Db4oFactory.OpenFile("../../MDBdraft.yap");

            //            sessionUser = User.GetUserByUsername("TOMNAZ1");



            //                        IObjectSet AllUsers = db.QueryByExample(typeof(User));
            //                        while (AllUsers.HasNext())
            //                        {
            //                            User a = (User)AllUsers.Next();
            //                            db.Delete(a);
            //                        }
            //
            //            User x = new User("password", "Tomnaz1", new List<Watchable>(), new List<Watchable>(), new FullName("Ahmad", "Hisham"), DateTime.Today, "dsiajofdsoifja",
            //                new List<Watchable>(), new List<Person>(), new List<string>());
            //            sessionUser.SetPassword("password2");
            //                        Console.WriteLine(sessionUser.GetPassword());
            //            Console.WriteLine(sessionUser.GetWatchableSubscriptions().Count);
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
            IObjectSet movie = db.QueryByExample(typeof(Movie));
            while (movie.HasNext())
            {
                movieClass = (Movie)movie.Next();
                Console.WriteLine(movieClass.GetID());
                Console.WriteLine(movieClass.GetTitleName());
                Console.WriteLine(movieClass.GetSubscribers());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
