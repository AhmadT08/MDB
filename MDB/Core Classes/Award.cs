using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;


namespace MDB
{
    class Award
    {
        private int _year;
        private string _category;
        private string _title;
        private bool _win;
        private bool _nomination;
        private Feature _feature;
        private Watchable _watchable;

        public Award(int year, string category, string title, bool win, bool nomination, Feature feature)
        {
            _year = year;
            _category = category;
            _title = title;
            _win = win;
            _nomination = nomination;
            _feature = feature;
            _watchable = null;
            MultimediaDB.db.Store(this);
        }

        public Award(int year, string category, string title, bool win, bool nomination, Watchable watchable)
        {
            _year = year;
            _category = category;
            _title = title;
            _win = win;
            _nomination = nomination;
            _watchable = watchable;
            _feature = null;
            MultimediaDB.db.Store(this);
        }

        public Award()
        {

        }

        public Award GetMatchingObject()
        {
            Award result = new Award();
            Award x = new Award();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Award));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Award)AllObjects[i];

                if (this.GetWatchable() == null)
                {
                    if (x.GetYear().Equals(this.GetYear())
                        && x.GetCategory().Equals(this.GetCategory())
                        && x.GetFeature().Equals(this.GetFeature())
                        && x.GetWin().Equals(this.GetWin()))
                    {
                        result = x;
                    }
                }
                else
                {
                    if (x.GetYear().Equals(this.GetYear())
                        && x.GetCategory().Equals(this.GetCategory())
                        && x.GetWatchable().Equals(this.GetWatchable())
                        && x.GetWin().Equals(this.GetWin()))
                    {
                        result = x;
                    }
                }
            }
            return result;
        }

        public static void Update(Object x)
        {
            MultimediaDB.db.Store(x);
        }

        public void Delete()
        {
            Award x = new Award();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Award));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Award)AllObjects[i];

                if (this.GetWatchable() == null)
                {
                    if (x.GetYear().Equals(this.GetYear())
                        && x.GetCategory().Equals(this.GetCategory())
                        && x.GetFeature().Equals(this.GetFeature())
                        && x.GetWin().Equals(this.GetWin()))
                    {
                        MultimediaDB.db.Delete(x);
                    }
                }
                else
                {
                    if (x.GetYear().Equals(this.GetYear())
                        && x.GetCategory().Equals(this.GetCategory())
                        && x.GetWatchable().Equals(this.GetWatchable())
                        && x.GetWin().Equals(this.GetWin()))
                    {
                        MultimediaDB.db.Delete(x);
                    }
                }
            }
        }

        public int GetYear()
        {
            return _year;
        }

        public void SetYear(int y)
        {
            Award DBObject = GetMatchingObject();
            _year = y;
            DBObject._year = y;
            Update(DBObject);
        }

        public string GetCategory()
        {
            return _category;
        }

        public void SetCategory(string c)
        {
            Award DBObject = GetMatchingObject();
            _category = c;
            DBObject._category = c;
            Update(DBObject);
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string t)
        {
            Award DBObject = GetMatchingObject();
            _title = t;
            DBObject._title = t;
            Update(DBObject);
        }

        public bool GetWin()
        {
            return _win;
        }

        public void SetWin(bool w)
        {
            Award DBObject = GetMatchingObject();
            _win = w;
            DBObject._win = w;
            Update(DBObject);
        }

        public bool GetNomination()
        {
            return _nomination;
        }

        public void GetNomination(bool n)
        {
            Award DBObject = GetMatchingObject();
            _nomination = n;
            DBObject._nomination = n;
            Update(DBObject);
        }

        public Feature GetFeature()
        {
            return _feature;
        }

        public void SetFeature(Feature f)
        {
            Award DBObject = GetMatchingObject();
            _feature = f;
            DBObject._feature = f;
            Update(DBObject);
        }

        public Watchable GetWatchable()
        {
            return _watchable;
        }

        public void SetWatchable(Watchable w)
        {
            Award DBObject = GetMatchingObject();
            _watchable = w;
            DBObject._watchable = w;
            Update(DBObject);
        }
    }
}
