using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.Runtime.Remoting;
using Cecil.FlowAnalysis.CodeStructure;
using Db4objects.Db4o;

namespace MDB
{
    class Watchable
    {
        private List<Award> _awardNominations;
        private List<Award> _awardWins;
        private List<string> _genre;
        private List<Person> _mainCast;
        private string _mpaaRating;
        private string _productionStatus;
        private double _rating;
        private List<User> _subscribers;
        private string _titleName;

        public Watchable(List<Award> awardNominations, List<Award> awardWins, List<string> genre,
                         List<Person> mainCast, string mpaaRating, string productionStatus, double rating,
                         List<User> subscribers, string titleName)
        {
            _awardNominations = awardNominations;
            _awardWins = awardWins;
            _genre = genre;
            _mainCast = mainCast;
            _mpaaRating = mpaaRating;
            _productionStatus = productionStatus;
            _rating = rating;
            _subscribers = subscribers;
            _titleName = titleName;
        }

        public Watchable()
        {

        }

        public void Update()
        {

        }

        public List<Award> GetAwardNominations()
        {
            return _awardNominations;
        }

        public void AddAwardNomination(Award awardNomination)
        {
            _awardNominations.Add(awardNomination);
            Update();
        }

        public List<Award> GetAwardWins()
        {
            return _awardWins;
        }

        public void AddAwardWin(Award awardWin)
        {
            _awardWins.Add(awardWin);
            Update();
        }

        public List<string> GetGenre()
        {
            return _genre;
        }

        public void SetGenre(List<string> genre)
        {
            _genre = genre;
            Update();
        }

        public List<Person> GetMainCast()
        {
            return _mainCast;
        }

        public void SetMainCast(List<Person> mainCast)
        {
            _mainCast = mainCast;
            Update();
        }

        public void AddToMainCast(Person cast)
        {
            _mainCast.Add(cast);
            Update();
        }

        public string GetMpaaRating()
        {
            return _mpaaRating;
        }

        public void SetMpaaRating(string mpaaRating)
        {
            _mpaaRating = mpaaRating;
            Update();
        }

        public string GetProductionStatus()
        {
            return _productionStatus;
        }

        public void SetProductionStatus(string productionStatus)
        {
            _productionStatus = productionStatus;
            Update();
        }

        public double GetRating()
        {
            return _rating;
        }

        public void SetRating(double rating)
        {
            _rating = rating;
            Update();
        }

        public List<User> GetSubscribers()
        {
            return _subscribers;
        }

        public void SetSubscribers(List<User> subscribers)
        {
            _subscribers = subscribers;
            Update();
        }

        public void AddSubscriber(User sub)
        {
            _subscribers.Add(sub);
            Update();
        }

        public void RemoveSubscriber(User sub)
        {
            _subscribers.Remove(sub);
            Update();
        }

        public string GetTitleName()
        {
            return _titleName;
        }

        public void SetTitleName(string titleName)
        {
            _titleName = titleName;
            Update();
        }

    }
}
