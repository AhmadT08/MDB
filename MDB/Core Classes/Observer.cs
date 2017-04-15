using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB.Core_Classes
{
    class Observer:IObserver
    {

        public string Observeremail { get; private set; }
        public Observer(User Email)
        {
            this.Observeremail= Email.GetEmail();
        }
        public void Update()
        {
            Console.WriteLine("{0}: A new product has arrived at store", this.Observeremail);
        }
    }
}

interface IObserver
{
    void Update();
}

