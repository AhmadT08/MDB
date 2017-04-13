using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace MDB
{
    class Show : Watchable
    {
        private int _seasons;
        private int _numberOfEpisodes;
        private DateTime _pilotDate;
        private List<Episode> _episodeList;

        public Show(List<Award> awardNominations, List<Award> awardWins, List<string> genre, List<Person> mainCast,
                     string mpaaRating, string productionStatus, double rating, List<User> subscribers, string titleName,
                     int seasons, int numberOfEpisodes, DateTime pilotDate, List<Episode> episodeList) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName)
        {
            _seasons = seasons;
            _numberOfEpisodes = numberOfEpisodes;
            _pilotDate = pilotDate;
            _episodeList = episodeList;
            MultimediaDB.db.Store(this);
        }

        public Show()
        {

        }

        public new void Update()
        {
            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Show)AllObjects[i];
                if (x.GetTitleName().Equals(GetTitleName()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public void AddEpisode(Episode episode)
        {
            _episodeList.Add(episode);
        }

        public DateTime getPilotDate()
        {
            return _pilotDate;
        }

        public void setPilotDate(DateTime date)
        {
            _pilotDate = date;
        }

        public int getNumberOfEpisodes()
        {
            return _numberOfEpisodes;
        }

        public void setNumberOfEpisodes(int ep)
        {
            _numberOfEpisodes = ep;
        }

        public int getSeasons()
        {
            return _seasons;
        }

        public void setSeasons(int s)
        {
            _seasons = s;
        }
    }

}

