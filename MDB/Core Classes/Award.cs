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

        public void DeleteMatchingObject()
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

        public void Update()
        {
            MultimediaDB.db.Store(this);
        }

        public int GetYear()
        {
            return _year;
        }

        public void SetYear(int y)
        {
//            DeleteMatchingObject();
            _year = y;
            Update();
        }

        public string GetCategory()
        {
            return _category;
        }

        public void SetCategory(string c)
        {
            _category = c;
            Update();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string t)
        {
            _title = t;
            Update();
        }

        public bool GetWin()
        {
            return _win;
        }

        public void SetWin(bool w)
        {
            _win = w;
            Update();
        }

        public bool GetNomination()
        {
            return _nomination;
        }

        public void GetNomination(bool n)
        {
            _nomination = n;
            Update();
        }

        public Feature GetFeature()
        {
            return _feature;
        }

        public void SetFeature(Feature f)
        {
            _feature = f;
            Update();
        }

        public Watchable GetWatchable()
        {
            return _watchable;
        }

        public void SetWatchable(Watchable w)
        {
            _watchable = w;
            Update();
        }
    }
}
