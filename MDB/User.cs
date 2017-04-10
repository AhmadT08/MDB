using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class User
    {
        private String _password;
        private String _username;
        private List<Watchable> _watched;
        private List<Watchable> _watchList;
        private FullName _name;
        private DateTime _dateOfBirth;
        private String _email;
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
        }

        public User()
        {
            
        }

        public string Password { get; set; }

        public string Username { get; set; }

        public List<Watchable> Watched { get; set; }

        public List<Watchable> WatchList { get; set; }

        public FullName Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public List<Watchable> WatchableSubscriptions { get; set; }

        public List<Person> PersonSubscriptions { get; set; }

        public void SubscribeToPerson(Person person)
        {
            person.AddSubscriber(this);
            PersonSubscriptions.Add(person);
        }

        public void UnsubscribeToPerson(Person person)
        {
            person.RemoveSubscriber(this);
            PersonSubscriptions.Remove(person);
        }

        public void SubscribeToWatchable(Watchable watchable)
        {
            watchable.AddSubscriber(this);
            WatchableSubscriptions.Add(watchable);
        }

        public void UnsubscribeToWatchable(Watchable watchable)
        {
            watchable.RemoveSubscriber(this);
            WatchableSubscriptions.Remove(watchable);
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
