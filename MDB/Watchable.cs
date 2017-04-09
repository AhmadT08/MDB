using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MDB
{
    class Watchable
    {
        private List<Award> awardNominations;
        private List<Award> awardWins;
        private List<String> genre;
        private List<Person> mainCast;
        private String MPAARating;
        private String productionStatus;
        private double rating;
        private List<User> subscribers;
        private String titleName;

        public Watchable(List<Award> awardNominations, List<Award> awardWins, List<String> genre, 
                         List<Person> mainCast, String MPAARating, String productionStatus, double rating, 
                         List<User> subscribers, String titleName)
        {
            this.awardNominations = awardNominations;
            this.awardWins = awardWins;
            this.genre = genre;
            this.mainCast = mainCast;
            this.MPAARating = MPAARating;
            this.productionStatus = productionStatus;
            this.rating = rating;
            this.subscribers = subscribers;
            this.titleName = titleName;
        }

        public Watchable()
        {

        }

        public List<Award> getAwardNominations()
        {
            return awardNominations;
        }

        public void addAwardNomination(Award awardNomination)
        {
            awardNominations.Add(awardNomination);
        }

        public List<Award> getAwardWins()
        {
            return awardWins;
        }

        public void addAwardWin(Award awardWin)
        {
            awardWins.Add(awardWin);
        }

        public List<String> getGenre()
        {
            return genre;
        }

        public void setGenre(List<String> genre)
        {
            this.genre = genre;
        }

        public List<Person> getMainCast()
        {
            return mainCast;
        }

        public void setMainCast(List<Person> mainCast)
        {
            this.mainCast = mainCast;
        }

        public void addToMainCast(Person cast)
        {
            mainCast.Add(cast);
        }

        public String getMPAARating()
        {
            return MPAARating;
        }

        public void setMPAARating(String MPAARating)
        {
            this.MPAARating = MPAARating;
        }

        public String getProductionStatus()
        {
            return productionStatus;
        }

        public void setProductionStatus(String productionStatus)
        {
            this.productionStatus = productionStatus;
        }

        public double getRating()
        {
            return rating;
        }

        public void setRating(double rating)
        {
            this.rating = rating;
        }

        public List<User> getSubscribers()
        {
            return subscribers;
        }

        public void setSubscribers(List<User> subscribers)
        {
            this.subscribers = subscribers;
        }

        public void addSubscriber(User sub)
        {
            subscribers.Add(sub);
        }

        public void removeSubscriber(User sub)
        {
            subscribers.Remove(sub);
        }

        public String getTitleName()
        {
            return titleName;
        }

        public void setTitleName(String titleName)
        {
            this.titleName = titleName;
        }

    }
}
