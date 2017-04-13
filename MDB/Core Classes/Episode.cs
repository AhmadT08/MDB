using System.Collections.Generic;
using Db4objects.Db4o;

namespace MDB
{
    internal class Episode
    {
        private int _number;
        private int _season;
        private List<Person> _cast;
        private double _rating;
        private Show _show;

        public Episode(int number, int season, List<Person> cast, double rating, Show show)
        {
            _number = number;
            _season = season;
            _cast = cast;
            _rating = rating;
            _show = show;
            MultimediaDB.db.Store(this);
        }

        public Episode()
        {
        }

        public void Update()
        {
            Episode x = new Episode();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Episode));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Episode)AllObjects[i];
                if (x.GetNumber().Equals(this.GetNumber())
                    && x.GetSeason().Equals(this.GetSeason())
                    && x.GetShow().Equals(this.GetShow()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public int GetNumber()
        {
            return _number;
        }

        public void SetNumber(int n)
        {
            _number = n;
            Update();
        }

        public int GetSeason()
        {
            return _season;
        }

        public void SetSeason(int s)
        {
            _season = s;
            Update();
        }

        public List<Person> GetCast()
        {
            return _cast;
        }

        public void SetCast(List<Person> c)
        {
            _cast = c;
            Update();
        }

        public double GetRating()
        {
            return _rating;
        }

        public void SetRating(double rating)
        {
            _rating = rating;
            Update();
        }

        public Show GetShow()
        {
            return _show;
        }

        public void SetShow(Show s)
        {
            _show = s;
            Update();
        }
    }
}