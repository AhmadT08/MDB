using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Person
    {
        public int Age { get; set; }

        public List<Award> AwardNominations { get; set; }

        public List<Award> AwardWins { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Ethnicity { get; set; }

        public List<Feature> Features { get; set; }

        public FullName Name { get; set; }

        public char Gender { get; set; }

        public int Height { get; set; }

        public string Nationality { get; set; }

        public List<User> Subscribers { get; set; }

        public Person(int age, List<Award> awardNominations, List<Award> awardWins, DateTime dateOfBirth, string ethnicity, List<Feature> features, FullName name, char gender, int height, string nationality, List<User> subscribers)
        {
            Age = age;
            AwardNominations = awardNominations;
            AwardWins = awardWins;
            DateOfBirth = dateOfBirth;
            Ethnicity = ethnicity;
            Features = features;
            Name = name;
            Gender = gender;
            Height = height;
            Nationality = nationality;
            Subscribers = subscribers;
        }

        public Person()
        {

        }
        public void AddSubscriber(User sub)
        {
            Subscribers.Add(sub);
        }

        public void RemoveSubscriber(User sub)
        {
            Subscribers.Remove(sub);
        }

        public void AddFeature(Feature feat)
        {
            Features.Add(feat);
        }

        public void RemoveFeature(Feature feat)
        {
            Features.Remove(feat);
        }

    }
}
