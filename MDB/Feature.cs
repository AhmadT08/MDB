using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Feature
    {
        private String _actingRole;
        private Watchable _entity;
        private Person _person;
        private String _productionRole;

        public Feature(string actingRole, Watchable entity, Person person, string productionRole)
        {
            _actingRole = actingRole;
            _entity = entity;
            _person = person;
            _productionRole = productionRole;
        }

        public Feature()
        {
            
        }

        public string ActingRole { get; set; }

        public Watchable Entity { get; set; }

        public Person ThePerson { get; set; }

        public string ProductionRole { get; set; }
    }
}
