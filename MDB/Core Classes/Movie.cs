using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using System.Drawing;

namespace MDB
{
    class Movie : Watchable
    {
        private DateTime _releaseDate;
        private int _runTime;

        public Movie(List<Award> awardNominations, List<Award> awardWins, List<string> genre,
                         List<Person> mainCast, string mpaaRating, string synopsis, string productionStatus, double rating,
                         List<User> subscribers, string titleName, Image poster, DateTime release, int time) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, synopsis, productionStatus, rating, subscribers, titleName, poster)
        {
            _releaseDate = release;
            _runTime = time;
            MultimediaDB.db.Store(this);
        }

        public Movie() : base()
        {

        }

        public override Watchable GetMatchingObject()
        {
            Movie result = new Movie();
            Movie x = new Movie();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Movie));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Movie)AllObjects[i];
                if (x.GetID().Equals(GetID()))
                {
                    result = x;
                }
            }
            return result;
        }

        public new static void Update(object x)
        {
            MultimediaDB.db.Store(x);
        }

        public override void Delete()
        {
            Movie x = new Movie();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Movie));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Movie)AllObjects[i];
                if (x.GetTitleName().Equals(GetTitleName()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public static Movie GetMovieByID(int ID)
        {
            Movie result = new Movie();

            Movie x = new Movie();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Movie));
            while (AllObjects.HasNext())
            {
                x = (Movie)AllObjects.Next();
                if (x.GetID().Equals(ID))
                {
                    result = x;
                }
            }

            return result;
        }

        public static Movie GetMovieByTitle(string title)
        {
            Movie result = new Movie();

            Movie x = new Movie();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Movie));
            while (AllObjects.HasNext())
            {
                x = (Movie)AllObjects.Next();
                if (x.GetTitleName().Equals(title))
                {
                    result = x;
                }
            }

            return result;
        }

        public static bool Exists(string title)
        {
            bool result = false;
            Movie x = new Movie();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Movie));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Movie)AllObjects[i];
                if (x.GetTitleName().Equals(title))
                {
                    result = true;
                }
            }

            return result;
        }

        public DateTime GetReleaseDate()
        {
            return _releaseDate;
        }

        public void SetReleaseDate(DateTime release)
        {
            Movie DBObject = (Movie)GetMatchingObject();
            _releaseDate = release;
            DBObject._releaseDate = release;
            Update(DBObject);
        }

        public int GetRunTime()
        {
            return _runTime;
        }

        public void SetRunTime(int run)
        {
            Movie DBObject = (Movie)GetMatchingObject();
            _runTime = run;
            DBObject._runTime = run;
            Update(DBObject);
        }
    }
}
