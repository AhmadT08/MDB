using System;
using System.Collections.Generic;
using Db4objects.Db4o;

namespace MDB
{
    internal class Episode
    {
        private int _number;
        private int _season;
        private string _title;
        private List<Person> _cast;
        private double _rating;
        private Show _show;

        public Episode(int number, int season, string title, List<Person> cast, double rating, Show show)
        {
            _number = number;
            _season = season;
            _title = title;
            _cast = cast;
            _rating = rating;
            _show = show;
            MultimediaDB.db.Store(this);
        }

        public Episode()
        {
        }

        public Episode GetMatchingObject()
        {
            Episode result = new Episode();
            Episode x = new Episode();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Episode));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Episode)AllObjects[i];
                if (x.GetNumber().Equals(GetNumber())
                    && x.GetSeason().Equals(GetSeason())
                    && x.GetShow().Equals(GetShow()))
                {
                    result = x;
                }
            }
            return result;
        }

        public static void Update(object x)
        {
            MultimediaDB.db.Store(x);
        }

        public void Delete()
        {
            Episode x = new Episode();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Episode));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Episode)AllObjects[i];
                if (x.GetNumber().Equals(GetNumber())
                    && x.GetSeason().Equals(GetSeason())
                    && x.GetShow().Equals(GetShow()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public int GetNumber()
        {
            return _number;
        }

        public void SetNumber(int n)
        {
            Episode DBObject = GetMatchingObject();
            _number = n;
            DBObject._number = n;
            Update(DBObject);
        }

        public int GetSeason()
        {
            return _season;
        }

        public void SetSeason(int s)
        {
            Episode DBObject = GetMatchingObject();
            _season = s;
            DBObject._season = s;
            Update(DBObject);
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string s)
        {
            Episode DBObject = GetMatchingObject();
            _title = s;
            DBObject._title = s;
            Update(DBObject);
        }

        public List<Person> GetCast()
        {
            return _cast;
        }

        public void SetCast(List<Person> c)
        {
            Episode DBObject = GetMatchingObject();
            _cast = c;
            DBObject._cast = c;
            Update(DBObject);
        }

        public double GetRating()
        {
            return _rating;
        }

        public void SetRating(double rating)
        {
            Episode DBObject = GetMatchingObject();
            _rating = rating;
            DBObject._rating = rating;
            Update(DBObject);
        }

        public Show GetShow()
        {
            return _show;
        }

        public void SetShow(Show s)
        {
            Episode DBObject = GetMatchingObject();
            _show = s;
            DBObject._show = s;
            Update(DBObject);
        }
    }
}