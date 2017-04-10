using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Db4objects.Db4o;

namespace MDB
{
    class Watchable
    {
        private List<Award> _awardNominations;
        private List<Award> _awardWins;
        private List<String> _genre;
        private List<Person> _mainCast;
        private String _mpaaRating;
        private String _productionStatus;
        private double _rating;
        private List<User> _subscribers;
        private String _titleName;

        public Watchable(List<Award> awardNominations, List<Award> awardWins, List<String> genre,
                         List<Person> mainCast, String mpaaRating, String productionStatus, double rating,
                         List<User> subscribers, String titleName)
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

        public List<Award> AwardNominations { get; set; }

        public List<Award> AwardWins { get; set; }

        public List<string> Genre { get; set; }

        public List<Person> MainCast { get; set; }

        public string MpaaRating { get; set; }

        public string ProductionStatus { get; set; }

        public double Rating { get; set; }

        public List<User> Subscribers { get; set; }

        public string TitleName { get; set; }

        public void AddAwardNomination(Award awardNomination)
        {
            _awardNominations.Add(awardNomination);
        }

        public void AddAwardWin(Award awardWin)
        {
            _awardWins.Add(awardWin);
        }

        public void AddToMainCast(Person cast)
        {
            _mainCast.Add(cast);
        }

        public void AddSubscriber(User sub)
        {
            _subscribers.Add(sub);
        }

        public void RemoveSubscriber(User sub)
        {
            _subscribers.Remove(sub);
        }

    }
}
