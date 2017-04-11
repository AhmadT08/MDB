using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Feature
    {
        public string ActingRole { get; set; }

        public Watchable Entity { get; set; }

        public Person ThePerson { get; set; }

        public string ProductionRole { get; set; }

        public Feature(string actingRole, Watchable entity, Person thePerson, string productionRole)
        {
            ActingRole = actingRole;
            Entity = entity;
            ThePerson = thePerson;
            ProductionRole = productionRole;
        }

        public Feature()
        {

        }


    }
}
