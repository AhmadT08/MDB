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

        public User GetMatchingObject()
        {
            User result = new User();
            User x = new User();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(User));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (User)AllObjects[i];
                if (x.GetUsername().Equals(GetUsername()))
                {
                    result = x;
                }
            }
            return result;
        }

        public static void Update(User x)
        {
            MultimediaDB.db.Store(x);
        }

        public void Delete()
        {
            User x = new User();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(User));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (User)AllObjects[i];
                if (x.GetUsername().Equals(GetUsername()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public static User GetUserByUsername(string username)
        {
            User result = new User();
            User x = new User();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(User));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (User)AllObjects[i];
                if (x.GetUsername().Equals(username))
                {
                    result = x;
                }
            }
            return result;
        }

        public string GetUsername()
        {
            return _username;
        }

        public void SetUsername(string user)
        {
            User DBObject = GetMatchingObject();
            _username = user;
            DBObject._username = user;
            Update(DBObject);
        }

        public string GetPassword()
        {
            return _password;
        }

        public void SetPassword(string pass)
        {
            User DBObject = GetMatchingObject();
            _password = pass;
            DBObject._password = pass;
            Update(DBObject);
        }

        public List<Watchable> GetWatched()
        {
            return _watched;
        }

        public void SetWatched(List<Watchable> watch)
        {
            User DBObject = GetMatchingObject();
            _watched = watch;
            DBObject._watched = watch;
            Update(DBObject);
        }

        public List<Watchable> GetWatchList()
        {
            return _watchList;
        }

        public void SetWatchList(List<Watchable> watch)
        {
            User DBObject = GetMatchingObject();
            _watchList = watch;
            DBObject._watchList = watch;
            Update(DBObject);
        }

        public FullName GetName()
        {
            return _name;
        }

        public void SetName(FullName f)
        {
            User DBObject = GetMatchingObject();
            _name = f;
            DBObject._name = f;
            Update(DBObject);
        }

        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public void SetDateOfBirth(DateTime f)
        {
            User DBObject = GetMatchingObject();
            _dateOfBirth = f;
            DBObject._dateOfBirth = f;
            Update(DBObject);
        }

        public string GetEmail()
        {
            return _email;
        }

        public void SetEmail(string e)
        {
            User DBObject = GetMatchingObject();
            _email = e;
            DBObject._email = e;
            Update(DBObject);
        }

        public List<Watchable> GetWatchableSubscriptions()
        {
            return _watchableSubscriptions;
        }

        public void SetWatchableSubscriptions(List<Watchable> watch)
        {
            User DBObject = GetMatchingObject();
            _watchableSubscriptions = watch;
            DBObject._watchableSubscriptions = watch;
            MultimediaDB.db.Store(DBObject._watchableSubscriptions);
        }

        public List<Person> GetPersonSubscriptions()
        {
            return _personSubscriptions;
        }

        public void SetPersonSubscriptions(List<Person> person)
        {
            User DBObject = GetMatchingObject();
            _personSubscriptions = person;
            DBObject._personSubscriptions = person;
            MultimediaDB.db.Store(DBObject._personSubscriptions);
        }

        public void SubscribeToPerson(Person person)
        {
            User DBObject = GetMatchingObject();
            person.AddSubscriber(this);
            //            _personSubscriptions.Add(person);
            DBObject._personSubscriptions.Add(person);
            MultimediaDB.db.Store(DBObject._personSubscriptions);
        }

        public void UnsubscribeToPerson(Person person)
        {
            User DBObject = GetMatchingObject();
            person.RemoveSubscriber(this);
            //            _personSubscriptions.Remove(person);
            DBObject._personSubscriptions.Remove(person);
            MultimediaDB.db.Store(DBObject._personSubscriptions);
        }

        public void SubscribeToWatchable(Watchable watchable)
        {
            User DBObject = GetMatchingObject();
            watchable.AddSubscriber(this);
            DBObject._watchableSubscriptions.Add(watchable);
            MultimediaDB.db.Store(DBObject._watchableSubscriptions);
        }

        public void UnsubscribeToWatchable(Watchable watchable)
        {
            User DBObject = GetMatchingObject();
            watchable.RemoveSubscriber(this);
            DBObject._watchableSubscriptions.Remove(watchable);
            MultimediaDB.db.Store(DBObject._watchableSubscriptions);
        }

        public void AddToWatched(Watchable watchable)
        {
            User DBObject = GetMatchingObject();
            //            _watched.Add(watchable);
            DBObject._watched.Add(watchable);
            MultimediaDB.db.Store(DBObject._watched);
        }

        public void RemoveFromWatched(Watchable watchable)
        {
            User DBObject = GetMatchingObject();
            //            _watched.Remove(watchable);
            DBObject._watched.Remove(watchable);
            MultimediaDB.db.Store(DBObject._watched);
        }

        public void AddToWatchList(Watchable watchable)
        {
            User DBObject = GetMatchingObject();
            //            _watchList.Add(watchable);
            DBObject._watchList.Add(watchable);
            MultimediaDB.db.Store(DBObject._watchList);
        }

        public void RemoveFromWatchList(Watchable watchable)
        {
            User DBObject = GetMatchingObject();
            //            _watchList.Remove(watchable);
            DBObject._watchList.Remove(watchable);
            MultimediaDB.db.Store(DBObject._watchList);
        }

        public void UpdateObservers()
        {
            Console.WriteLine("{0}: A new product has arrived at store", this.GetEmail());
        }
    }
}
