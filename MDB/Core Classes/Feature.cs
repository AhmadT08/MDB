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
            MultimediaDB.db.Store(this);
        }

        public Feature()
        {

        }

        public void Update()
        {
            Feature x = new Feature();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Feature));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Feature)AllObjects[i];
                if (x.GetActingRole().Equals(this.GetActingRole())
                    && x.GetEntity().Equals(this.GetEntity())
                    && x.GetPerson().Equals(this.GetPerson()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public string GetActingRole()
        {
            return _actingRole;
        }

        public void SetActingRole(string role)
        {
            _actingRole = role;
            Update();
        }

        public string GetProductionRole()
        {
            return _productionRole;
        }

        public void SetProductionRole(string role)
        {
            _productionRole = role;
            Update();
        }

        public Watchable GetEntity()
        {
            return _entity;
        }

        public void SetEntity(Watchable en)
        {
            _entity = en;
            Update();
        }

        public Person GetPerson()
        {
            return _person;
        }

        public void SetPerson(Person p)
        {
            _person = p;
            Update();
        }
    }
}
