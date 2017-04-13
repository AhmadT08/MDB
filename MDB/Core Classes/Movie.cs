using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace MDB
{
    class Movie : Watchable
    {
        private DateTime _releaseDate;
        private int _runTime;

        public Movie(List<Award> awardNominations, List<Award> awardWins, List<string> genre,
                         List<Person> mainCast, string mpaaRating, string productionStatus, double rating,
                         List<User> subscribers, string titleName, DateTime release, int time) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName)
        {
            _releaseDate = release;
            _runTime = time;
            MultimediaDB.db.Store(this);
        }

        public Movie() : base()
        {

        }

        public new void Update()
        {
            Movie x = new Movie();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Movie));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Movie)AllObjects[i];
                if (x.GetTitleName().Equals(GetTitleName()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public DateTime GetReleaseDate()
        {
            return _releaseDate;
        }

        public void SetReleaseDate(DateTime release)
        {
            _releaseDate = release;
            Update();
        }

        public int GetRunTime()
        {
            return _runTime;
        }

        public void SetRunTime(int run)
        {
            _runTime = run;
            Update();
        }
    }
}
