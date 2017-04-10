using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Person
    {
        private int _age;
        private List<Award> _awardNominations;
        private List<Award> _awardWins;
        private DateTime _dateOfBirth;
        private String _ethnicity;
        private List<Feature> _features;
        private FullName _name;
        private char _gender;
        private int _height;
        private String _nationality;
        private List<User> _subscribers;

        public Person(int age, List<Award> awardNominations, List<Award> awardWins, DateTime dateOfBirth, string ethnicity, List<Feature> features, FullName name, char gender, int height, string nationality, List<User> subscribers)
        {
            _age = age;
            _awardNominations = awardNominations;
            _awardWins = awardWins;
            _dateOfBirth = dateOfBirth;
            _ethnicity = ethnicity;
            _features = features;
            _name = name;
            _gender = gender;
            _height = height;
            _nationality = nationality;
            _subscribers = subscribers;
        }

        public Person()
        {
            
        }

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

        public void AddSubscriber(User sub)
        {
            _subscribers.Add(sub);
        }

        public void RemoveSubscriber(User sub)
        {
            _subscribers.Remove(sub);
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
