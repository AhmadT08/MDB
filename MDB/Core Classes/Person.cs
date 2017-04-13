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

        public Person GetMatchingObject()
        {
            Person result = new Person();
            Person x = new Person();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Person)AllObjects[i];
                if (x.GetName().Equals(this.GetName()))
                {
                    result = x;
                }
            }
            return result;
        }

        public static void Update(Object x)
        {
            MultimediaDB.db.Store(x);
        }

        public void Delete()
        {
            Person x = new Person();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Person)AllObjects[i];
                if (x.GetName().Equals(this.GetName()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int a)
        {
            Person DBObject = GetMatchingObject();
            _age = a;
            DBObject._age = a;
            Update(DBObject);
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int a)
        {
            Person DBObject = GetMatchingObject();
            _height = a;
            DBObject._height = a;
            Update(DBObject);
        }

        public List<Award> GetAwardNominations()
        {
            return _awardNominations;
        }

        public void SetAwardNominations(List<Award> nom)
        {
            Person DBObject = GetMatchingObject();
            _awardNominations = nom;
            DBObject._awardNominations = nom;
            Update(DBObject);
        }

        public List<Award> GetAwardWins()
        {
            return _awardWins;
        }

        public void SetAwardWins(List<Award> win)
        {
            Person DBObject = GetMatchingObject();
            _awardWins = win;
            DBObject._awardWins = win;
            Update(DBObject);
        }

        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public void SetDateOfBirth(DateTime f)
        {
            Person DBObject = GetMatchingObject();
            _dateOfBirth = f;
            DBObject._dateOfBirth = f;
            Update(DBObject);
        }

        public string GetEthnicity()
        {
            return _ethnicity;
        }

        public void SetEthnicity(string eth)
        {
            Person DBObject = GetMatchingObject();
            _ethnicity = eth;
            DBObject._ethnicity = eth;
            Update(DBObject);
        }

        public string GetNationality()
        {
            return _nationality;
        }

        public void SetNationality(string nat)
        {
            Person DBObject = GetMatchingObject();
            _nationality = nat;
            DBObject._nationality = nat;
            Update(DBObject);
        }

        public FullName GetName()
        {
            return _name;
        }

        public void SetName(FullName f)
        {
            Person DBObject = GetMatchingObject();
            _name = f;
            DBObject._name = f;
            Update(DBObject);
        }

        public List<Feature> GetFeatures()
        {
            return _features;
        }

        public void SetFeatures(List<Feature> feat)
        {
            Person DBObject = GetMatchingObject();
            _features = feat;
            DBObject._features = feat;
            Update(DBObject);
        }

        public char GetGender()
        {
            return _gender;
        }

        public void SetGender(char f)
        {
            Person DBObject = GetMatchingObject();
            _gender = f;
            DBObject._gender = f;
            Update(DBObject);
        }

        public List<User> GetSubscribers()
        {
            return _subscribers;
        }

        public void SetSubscribers(List<User> subs)
        {
            Person DBObject = GetMatchingObject();
            _subscribers = subs;
            DBObject._subscribers = subs;
            Update(DBObject);
        }

        public void AddSubscriber(User sub)
        {
            Person DBObject = GetMatchingObject();
            _subscribers.Add(sub);
            DBObject._subscribers.Add(sub);
            Update(DBObject);
        }

        public void RemoveSubscriber(User sub)
        {
            Person DBObject = GetMatchingObject();
            _subscribers.Remove(sub);
            DBObject._subscribers.Remove(sub);
            Update(DBObject);
        }

        public void AddFeature(Feature feat)
        {
            Person DBObject = GetMatchingObject();
            _features.Add(feat);
            DBObject._features.Add(feat);
            Update(DBObject);
        }

        public void RemoveFeature(Feature feat)
        {
            Person DBObject = GetMatchingObject();
            _features.Remove(feat);
            DBObject._features.Remove(feat);
            Update(DBObject);
        }

        public void AddAwardNomination(Award awardNomination)
        {
            Person DBObject = GetMatchingObject();
            _awardNominations.Add(awardNomination);
            DBObject._awardNominations.Add(awardNomination);
            Update(DBObject);
        }

        public void AddAwardWin(Award awardWin)
        {
            Person DBObject = GetMatchingObject();
            _awardWins.Add(awardWin);
            DBObject._awardWins.Add(awardWin);
            Update(DBObject);
        }

    }
}
