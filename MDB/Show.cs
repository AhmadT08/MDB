using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Show : Watchable
    {
        private int seasons;
        private int numberOfEpisodes;
        private DateTime pilotDate;

        public Show(List<Award> awardNominations, List<Award> awardWins, List<String> genre,
                         List<Person> mainCast, String MPAARating, String productionStatus, double rating,
                         List<User> subscribers, String titleName, DateTime pilot, int episodes, int season) : base(awardNominations,
                         awardWins, genre, mainCast, MPAARating, productionStatus, rating, subscribers, titleName)
        {
            this.seasons = season;
            this.numberOfEpisodes = episodes;
            this.pilotDate = pilot;
        }

        public Show() : base()
        {

        }

        public DateTime getPilotDate()
        {
            return pilotDate;
        }

        public void setPilotDate(DateTime date)
        {
            pilotDate = date;
        }

        public int getNumberOfEpisodes()
        {
            return numberOfEpisodes;
        }

        public void setNumberOfEpisodes(int ep)
        {
            numberOfEpisodes = ep;
        }

        public int getSeasons()
        {
            return seasons;
        }

        public void setSeasons(int s)
        {
            seasons = s;
        }
    }
}
