using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Show : Watchable
    {
        private int _seasons;
        private int _numberOfEpisodes;
        private DateTime _pilotDate;
        private List<Episode> _episodeList;

        public int Seasons { get; set; }

        public int NumberOfEpisodes { get; set; }

        public DateTime PilotDate { get; set; }

        public List<Episode> EpisodeList { get; set; }

        public Show(List<Award> awardNominations, List<Award> awardWins, List<String> genre,
                         List<Person> mainCast, String mpaaRating, String productionStatus, double rating,
                         List<User> subscribers, String titleName, DateTime pilot, int episodes, int season, List<Episode> epList) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName)
        {
            Seasons = season;
            NumberOfEpisodes = episodes;
            PilotDate = pilot;
            EpisodeList = epList;
        }

        public Show(List<Award> awardNominations, List<Award> awardWins, List<String> genre,
                         List<Person> mainCast, String mpaaRating, String productionStatus, double rating,
                         List<User> subscribers, String titleName, DateTime pilot, int episodes, int season) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName)
        {
            Seasons = season;
            NumberOfEpisodes = episodes;
            PilotDate = pilot;
        }

        public Show() : base()
        {

        }

        public void AddEpisode(Episode episode)
        {
            EpisodeList.Add(episode);
        }
        
    }
}
