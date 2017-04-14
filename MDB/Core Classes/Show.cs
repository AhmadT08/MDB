using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using System.Drawing;

namespace MDB
{
    class Show : Watchable
    {
        private int _seasons;
        private int _numberOfEpisodes;
        private DateTime _pilotDate;
        private List<Episode> _episodeList;

        public Show(List<Award> awardNominations, List<Award> awardWins, List<string> genre, List<Person> mainCast,
                     string mpaaRating, string productionStatus, double rating, List<User> subscribers, string titleName, Image poster,
                     int seasons, int numberOfEpisodes, DateTime pilotDate, List<Episode> episodeList) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, productionStatus, rating, subscribers, titleName, poster)
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

        public Show GetMatchingObject()
        {
            Show result = new Show();
            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Show)AllObjects[i];
                if (x.GetTitleName().Equals(GetTitleName()))
                {
                    result = x;
                }
            }
            return result;
        }

        public new static void Update(Object x)
        {
            MultimediaDB.db.Store(x);
        }

        public void Delete()
        {
            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Show)AllObjects[i];
                if (x.GetTitleName().Equals(GetTitleName()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public void AddEpisode(Episode episode)
        {
            Show DBObject = GetMatchingObject();
            _episodeList.Add(episode);
            DBObject._episodeList.Add(episode);
            Update(DBObject);
        }

        public DateTime getPilotDate()
        {
            return _pilotDate;
        }

        public void setPilotDate(DateTime date)
        {
            Show DBObject = GetMatchingObject();
            _pilotDate = date;
            DBObject._pilotDate = date;
            Update(DBObject);
        }

        public int getNumberOfEpisodes()
        {
            return _numberOfEpisodes;
        }

        public void setNumberOfEpisodes(int ep)
        {
            Show DBObject = GetMatchingObject();
            _numberOfEpisodes = ep;
            DBObject._numberOfEpisodes = ep;
            Update(DBObject);
        }

        public int getSeasons()
        {
            return _seasons;
        }

        public void setSeasons(int s)
        {
            Show DBObject = GetMatchingObject();
            _seasons = s;
            DBObject._seasons = s;
            Update(DBObject);
        }
    }

}

