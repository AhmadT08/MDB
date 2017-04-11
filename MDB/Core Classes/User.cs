using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class User
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public List<Watchable> Watched { get; set; }

        public List<Watchable> WatchList { get; set; }

        public FullName Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public List<Watchable> WatchableSubscriptions { get; set; }

        public List<Person> PersonSubscriptions { get; set; }

        public User(string password, string username, List<Watchable> watched, List<Watchable> watchList, FullName name, DateTime dateOfBirth, string email, List<Watchable> watchableSubscriptions, List<Person> personSubscriptions)
        {
            Password = password;
            Username = username;
            Watched = watched;
            WatchList = watchList;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            WatchableSubscriptions = watchableSubscriptions;
            PersonSubscriptions = personSubscriptions;
        }

        public User()
        {

        }

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
            Watched.Add(watchable);
        }

        public void RemoveFromWatched(Watchable watchable)
        {
            Watched.Remove(watchable);
        }

        public void AddToWatchList(Watchable watchable)
        {
            WatchList.Add(watchable);
        }

        public void RemoveFromWatchList(Watchable watchable)
        {
            WatchList.Remove(watchable);
        }
    }
}
