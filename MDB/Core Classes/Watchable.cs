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
        public List<Award> AwardNominations { get; set; }

        public List<Award> AwardWins { get; set; }

        public List<string> Genre { get; set; }

        public List<Person> MainCast { get; set; }

        public string MpaaRating { get; set; }

        public string ProductionStatus { get; set; }

        public double Rating { get; set; }

        public List<User> Subscribers { get; set; }

        public string TitleName { get; set; }

        public Watchable(List<Award> awardNominations, List<Award> awardWins, List<string> genre, List<Person> mainCast, string mpaaRating, string productionStatus, double rating, List<User> subscribers, string titleName)
        {
            AwardNominations = awardNominations;
            AwardWins = awardWins;
            Genre = genre;
            MainCast = mainCast;
            MpaaRating = mpaaRating;
            ProductionStatus = productionStatus;
            Rating = rating;
            Subscribers = subscribers;
            TitleName = titleName;
        }

        public Watchable()
        {

        }

        public void AddAwardNomination(Award awardNomination)
        {
            AwardNominations.Add(awardNomination);
        }

        public void AddAwardWin(Award awardWin)
        {
            AwardWins.Add(awardWin);
        }

        public void AddToMainCast(Person cast)
        {
            MainCast.Add(cast);
        }

        public void AddSubscriber(User sub)
        {
            Subscribers.Add(sub);
        }

        public void RemoveSubscriber(User sub)
        {
            Subscribers.Remove(sub);
        }

    }
}
