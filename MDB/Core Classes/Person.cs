using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace MDB
{
    class Person
    {
        private int _age;
        private List<Award> _awardNominations;
        private List<Award> _awardWins;
        private DateTime _dateOfBirth;
        private string _ethnicity;
        private List<Feature> _features;
        private FullName _name;
        private char _gender;
        private int _height;
        private string _nationality;
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
            MultimediaDB.db.Store(this);
        }

        public Person()
        {

        }

        public void Update()
        {
            Person x = new Person();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Person)AllObjects[i];
                if (x.GetName().Equals(this.GetName()))
                {
                    MultimediaDB.db.Store(this);
                }
            }
        }

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int a)
        {
            _age = a;
            Update();
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int a)
        {
            _height = a;
            Update();
        }

        public List<Award> GetAwardNominations()
        {
            return _awardNominations;
        }

        public void SetAwardNominations(List<Award> nom)
        {
            _awardNominations = nom;
            Update();
        }

        public List<Award> GetAwardWins()
        {
            return _awardWins;
        }

        public void SetAwardWins(List<Award> win)
        {
            _awardWins = win;
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

        public string GetEthnicity()
        {
            return _ethnicity;
        }

        public void SetEthnicity(string eth)
        {
            _ethnicity = eth;
            Update();
        }

        public string GetNationality()
        {
            return _nationality;
        }

        public void SetNationality(string nat)
        {
            _nationality = nat;
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

        public List<Feature> GetFeatures()
        {
            return _features;
        }

        public void SetFeatures(List<Feature> feat)
        {
            _features = feat;
            Update();
        }

        public char GetGender()
        {
            return _gender;
        }

        public void SetGender(char f)
        {
            _gender = f;
            Update();
        }

        public List<User> GetSubscribers()
        {
            return _subscribers;
        }

        public void SetSubscribers(List<User> subs)
        {
            _subscribers = subs;
            Update();
        }

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
            _features.Add(feat);
        }

        public void RemoveFeature(Feature feat)
        {
            _features.Remove(feat);
        }

        public void AddAwardNomination(Award awardNomination)
        {
            _awardNominations.Add(awardNomination);
            Update();
        }

        public void AddAwardWin(Award awardWin)
        {
            _awardWins.Add(awardWin);
            Update();
        }

    }
}
