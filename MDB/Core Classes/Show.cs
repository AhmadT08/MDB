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
                     string mpaaRating, string synopsis, string productionStatus, double rating, List<User> subscribers, string titleName, Image poster,
                     int seasons, int numberOfEpisodes, DateTime pilotDate, List<Episode> episodeList) : base(awardNominations,
                         awardWins, genre, mainCast, mpaaRating, synopsis, productionStatus, rating, subscribers, titleName, poster)
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

        public override Watchable GetMatchingObject()
        {
            Show result = new Show();
            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Show)AllObjects[i];
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

        public static Show GetShowByID(int ID)
        {
            Show result = new Show();

            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            while (AllObjects.HasNext())
            {
                x = (Show)AllObjects.Next();
                if (x.GetID().Equals(ID))
                {
                    result = x;
                }
            }

            return result;
        }

        public static Show GetShowByTitle(string title)
        {
            Show result = new Show();

            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Show)AllObjects[i];
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
            Show x = new Show();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Show));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Show)AllObjects[i];
                if (x.GetTitleName().Equals(title))
                {
                    result = true;
                }
            }

            return result;
        }

        public void AddEpisode(Episode episode)
        {
            Show DBObject = (Show)GetMatchingObject();
            //            _episodeList.Add(episode);
            //            _numberOfEpisodes++;
            DBObject._episodeList.Add(episode);
            DBObject._numberOfEpisodes++;
            MultimediaDB.db.Store(DBObject._episodeList);
            Update(DBObject);

            Notify("A new episode of " + GetTitleName() + " has been released. Episode " + episode.GetNumber() + ", titled " + episode.GetTitle() + ".");
        }

        public DateTime GetPilotDate()
        {
            return _pilotDate;
        }

        public void SetPilotDate(DateTime date)
        {
            Show DBObject = (Show)GetMatchingObject();
            _pilotDate = date;
            DBObject._pilotDate = date;
            Update(DBObject);
        }

        public int GetNumberOfEpisodes()
        {
            return _numberOfEpisodes;
        }

        public void SetNumberOfEpisodes(int ep)
        {
            Show DBObject = (Show)GetMatchingObject();
            _numberOfEpisodes = ep;
            DBObject._numberOfEpisodes = ep;
            Update(DBObject);
        }

        public int GetSeasons()
        {
            return _seasons;
        }

        public void SetSeasons(int s)
        {
            Show DBObject = (Show)GetMatchingObject();
            _seasons = s;
            DBObject._seasons = s;
            Update(DBObject);
        }
    }

}

