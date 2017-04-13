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

        public void Update()
        {
            FullName x = new FullName();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(FullName));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (FullName)AllObjects[i];
                if (x.GetFirstName().Equals(this.GetFirstName()) && x.GetLastName().Equals(this.GetLastName()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string name)
        {
            _firstName = name;
            Update();
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetLastName(string name)
        {
            _lastName = name;
            Update();
        }
    }
}
