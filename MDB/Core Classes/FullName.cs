using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace MDB
{
    class FullName
    {
        private string _firstName;
        private string _lastName;

        public FullName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            MultimediaDB.db.Store(this);
        }

        public FullName()
        {

        }

        public FullName GetMatchingObject()
        {
            FullName result = new FullName();
            FullName x = new FullName();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(FullName));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (FullName)AllObjects[i];
                if (x.GetFirstName().Equals(GetFirstName()) && x.GetLastName().Equals(GetLastName()))
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
            FullName x = new FullName();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(FullName));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (FullName)AllObjects[i];
                if (x.GetFirstName().Equals(GetFirstName()) && x.GetLastName().Equals(GetLastName()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string name)
        {
            FullName DBObject = GetMatchingObject();
            _firstName = name;
            DBObject._firstName = name;
            Update(DBObject);
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetLastName(string name)
        {
            FullName DBObject = GetMatchingObject();
            _lastName = name;
            DBObject._lastName = name;
            Update(DBObject);
        }
    }
}
