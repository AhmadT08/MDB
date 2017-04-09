using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Movie : Watchable
    {
        private DateTime releaseDate;
        private int runTime;

        public Movie(List<Award> awardNominations, List<Award> awardWins, List<String> genre,
                         List<Person> mainCast, String MPAARating, String productionStatus, double rating,
                         List<User> subscribers, String titleName, DateTime release, int time) : base(awardNominations,
                         awardWins, genre, mainCast, MPAARating, productionStatus, rating, subscribers, titleName)
        {
            this.releaseDate = release;
            this.runTime = time;
        }

        public Movie() : base()
        {
            
        }

        public DateTime getReleaseDate()
        {
            return releaseDate;
        }

        public void setReleaseDate(DateTime date)
        {
            releaseDate = date;
        }

        public int getRunTime()
        {
            return runTime;
        }

        public void setRunTime(int time)
        {
            runTime = time;
        }

    }
}
