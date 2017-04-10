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
        public Movie(List<Award> awardNominations, List<Award> awardWins, List<String> genre,
                         List<Person> mainCast, String mpaaRating, String productionStatus, double rating,
                         List<User> subscribers, String titleName, DateTime release, int time) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName)
        {
            ReleaseDate = release;
            RunTime = time;
        }

        public Movie() : base()
        {
            
        }

        public DateTime ReleaseDate { get; set; }

        public int RunTime { get; set; }


    }
}
