using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace MDB
{
    class User
    {
        private string _password;
        private string _username;
        private List<Watchable> _watched;
        private List<Watchable> _watchList;
        private FullName _name;
        private DateTime _dateOfBirth;
        private string _email;
        private List<Watchable> _watchableSubscriptions;
        private List<Person> _personSubscriptions;

        public User(string password, string username, List<Watchable> watched, List<Watchable> watchList, FullName name, DateTime dateOfBirth, string email, List<Watchable> watchableSubscriptions, List<Person> personSubscriptions)
        {
            _password = password;
            _username = username;
            _watched = watched;
            _watchList = watchList;
            _name = name;
            _dateOfBirth = dateOfBirth;
            _email = email;
            _watchableSubscriptions = watchableSubscriptions;
            _personSubscriptions = personSubscriptions;
            MultimediaDB.db.Store(this);
        }

        public User()
        {

        }

        public void Update()
        {
            User x = new User();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(User));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (User)AllObjects[i];
                if (x.GetUsername().Equals(GetUsername()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public string GetUsername()
        {
            return _username;
        }

        public void SetUsername(string user)
        {
            _username = user;
            Update();
        }

        public string GetPassword()
        {
            return _password;
        }

        public void SetPassword(string pass)
        {
            _password = pass;
            Update();
        }

        public List<Watchable> GetWatched()
        {
            return _watched;
        }

        public void SetWatched(List<Watchable> watch)
        {
            _watched = watch;
            Update();
        }

        public List<Watchable> GetWatchList()
        {
            return _watchList;
        }

        public void SetWatchList(List<Watchable> watch)
        {
            _watchList = watch;
            Update();
        }

        public FullName GetName()
        {
            return _name;
        }

        public void SetName(FullName f)
        {
            _name = f;
            Update();
        }

        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public void SetDateOfBirth(DateTime f)
        {
            _dateOfBirth = f;
            Update();
        }

        public string GetEmail()
        {
            return _email;
        }

        public void SetEmail(string e)
        {
            _email = e;
            Update();
        }

        public List<Watchable> GetWatchableSubscriptions()
        {
            return _watchableSubscriptions;
        }

        public void SetWatchableSubscriptions(List<Watchable> watch)
        {
            _watchableSubscriptions = watch;
            Update();
        }

        public List<Person> GetPersonSubscriptions()
        {
            return _personSubscriptions;
        }

        public void SetPersonSubscriptions(List<Person> person)
        {
            _personSubscriptions = person;
            Update();
        }

        public void SubscribeToPerson(Person person)
        {
            person.AddSubscriber(this);
            _personSubscriptions.Add(person);
        }

        public void UnsubscribeToPerson(Person person)
        {
            person.RemoveSubscriber(this);
            _personSubscriptions.Remove(person);
        }

        public void SubscribeToWatchable(Watchable watchable)
        {
            watchable.AddSubscriber(this);
            _watchableSubscriptions.Add(watchable);
        }

        public void UnsubscribeToWatchable(Watchable watchable)
        {
            watchable.RemoveSubscriber(this);
            _watchableSubscriptions.Remove(watchable);
        }

        public void AddToWatched(Watchable watchable)
        {
            _watched.Add(watchable);
        }

        public void RemoveFromWatched(Watchable watchable)
        {
            _watched.Remove(watchable);
        }

        public void AddToWatchList(Watchable watchable)
        {
            _watchList.Add(watchable);
        }

        public void RemoveFromWatchList(Watchable watchable)
        {
            _watchList.Remove(watchable);
        }
    }
}
