using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class FullName
    {
        private String _firstName;
        private String _lastName;

        public FullName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
