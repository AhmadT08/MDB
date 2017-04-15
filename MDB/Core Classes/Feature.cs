using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace MDB
{
    class Feature
    {
        private string _actingRole;
        private Watchable _entity;
        private Person _person;
        private string _productionRole;

        public Feature(string actingRole, Watchable entity, Person person, string productionRole)
        {
            _actingRole = actingRole;
            _entity = entity;
            _person = person;
            _productionRole = productionRole;
            if (!Exists(_person, _entity))
            {
                MultimediaDB.db.Store(this);
            }
        }

        public Feature()
        {

        }

        public Feature GetMatchingObject()
        {
            Feature result = new Feature();
            Feature x = new Feature();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Feature));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Feature)AllObjects[i];
                if (x.GetActingRole().Equals(GetActingRole())
                    && x.GetEntity().Equals(GetEntity())
                    && x.GetPerson().Equals(GetPerson()))
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
            Feature x = new Feature();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Feature));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Feature)AllObjects[i];
                if (x.GetActingRole().Equals(GetActingRole())
                    && x.GetEntity().Equals(GetEntity())
                    && x.GetPerson().Equals(GetPerson()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public static bool Exists(Person person, Watchable entity)
        {
            bool result = false;
            Feature x = new Feature();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Feature));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Feature)AllObjects[i];
                if (x.GetEntity().Equals(entity)
                    && x.GetPerson().Equals(person))
                {
                    result = true;
                }
            }
            return result;
        }

        public string GetActingRole()
        {
            return _actingRole;
        }

        public void SetActingRole(string role)
        {
            Feature DBObject = GetMatchingObject();
            _actingRole = role;
            DBObject._actingRole = role;
            Update(DBObject);
        }

        public string GetProductionRole()
        {
            return _productionRole;
        }

        public void SetProductionRole(string role)
        {
            Feature DBObject = GetMatchingObject();
            _productionRole = role;
            DBObject._productionRole = role;
            Update(DBObject);
        }

        public Watchable GetEntity()
        {
            return _entity;
        }

        public void SetEntity(Watchable en)
        {
            Feature DBObject = GetMatchingObject();
            _entity = en;
            DBObject._entity = en;
            Update(DBObject);
        }

        public Person GetPerson()
        {
            return _person;
        }

        public void SetPerson(Person p)
        {
            Feature DBObject = GetMatchingObject();
            _person = p;
            DBObject._person = p;
            Update(DBObject);
        }
    }
}
