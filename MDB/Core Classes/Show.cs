using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Show : Watchable
    {
        public int Seasons { get; set; }

        public int NumberOfEpisodes { get; set; }

        public DateTime PilotDate { get; set; }

        public List<Episode> EpisodeList { get; set; }

        public Show(List<Award> awardNominations, List<Award> awardWins, List<string> genre, List<Person> mainCast,
                     string mpaaRating, string productionStatus, double rating, List<User> subscribers, string titleName,
                     int seasons, int numberOfEpisodes, DateTime pilotDate, List<Episode> episodeList) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName)
        {
            Seasons = seasons;
            NumberOfEpisodes = numberOfEpisodes;
            PilotDate = pilotDate;
            EpisodeList = episodeList;
        }

        public Show()
        {

        }

        public void AddEpisode(Episode episode)
        {
            EpisodeList.Add(episode);
        }

    }
}
