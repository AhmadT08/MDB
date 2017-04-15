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
        private readonly int _ID;
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
            _ID = MultimediaDB.db.QueryByExample(typeof(Person)).Count + 1;
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

            if (!Exists(_name, _age))
            {
                MultimediaDB.db.Store(this);
            }
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
                if (x.GetName().Equals(GetName()))
                {
                    result = x;
                }
            }
            return result;
        }

        public static void Update(object x)
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
                if (x.GetID().Equals(GetID()))
                {
                    MultimediaDB.db.Delete(x);
                }
            }
        }

        public static Person GetPersonByID(int ID)
        {
            Person result = new Person();

            Person x = new Person();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Person)AllObjects[i];
                if (x.GetID().Equals(ID))
                {
                    result = x;
                }
            }
            return result;
        }

        public static Person GetPersonByNameAge(FullName name, int age)
        {
            Person result = new Person();
            Person x = new Person();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));
            for (int i = 0; i < AllObjects.Count; i++)
            {
                x = (Person)AllObjects[i];
                if (x.GetName().GetFirstName().Equals(name.GetFirstName()) &&
                    x.GetName().GetLastName().Equals(name.GetLastName()) &&
                    x.GetAge().Equals(age))
                {
                    result = x;
                }
            }
            return result;
        }

        public static bool Exists(FullName name, int age)
        {
            bool result = false;
            Person x = new Person();
            IObjectSet AllObjects = MultimediaDB.db.QueryByExample(typeof(Person));

            try
            {
                for (int i = 0; i < AllObjects.Count; i++)
                {
                    x = (Person)AllObjects[i];
                    if (x.GetName().GetFirstName().Equals(name.GetFirstName()) &&
                        x.GetName().GetLastName().Equals(name.GetLastName()) &&
                        x.GetAge().Equals(age))
                    {
                        result = true;
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
            }
            return result;
        }

        public int GetID()
        {
            return _ID;
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
            MultimediaDB.db.Store(DBObject._awardNominations);
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
            MultimediaDB.db.Store(DBObject._awardWins);
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
            MultimediaDB.db.Store(DBObject._features);
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
            MultimediaDB.db.Store(DBObject._subscribers);
        }

        public void AddSubscriber(User sub)
        {
            Person DBObject = GetMatchingObject();
            //            _subscribers.Add(sub);
            DBObject._subscribers.Add(sub);
            MultimediaDB.db.Store(DBObject._subscribers);
        }

        public void RemoveSubscriber(User sub)
        {
            Person DBObject = GetMatchingObject();
            //            _subscribers.Remove(sub);
            DBObject._subscribers.Remove(sub);
            MultimediaDB.db.Store(DBObject._subscribers);
        }

        public void AddFeature(Feature feat)
        {
            Person DBObject = GetMatchingObject();
            //            _features.Add(feat);
            DBObject._features.Add(feat);
            MultimediaDB.db.Store(DBObject._features);
            Notify(_name.GetFirstName() + " " + _name.GetLastName() + " features in "
                + feat.GetEntity().GetTitleName() + " for the role of " + feat.GetActingRole());
        }

        public void RemoveFeature(Feature feat)
        {
            Person DBObject = GetMatchingObject();
            //            _features.Remove(feat);
            DBObject._features.Remove(feat);
            MultimediaDB.db.Store(DBObject._features);
        }

        public void AddAwardNomination(Award awardNomination)
        {
            Person DBObject = GetMatchingObject();
            //            _awardNominations.Add(awardNomination);
            DBObject._awardNominations.Add(awardNomination);
            MultimediaDB.db.Store(DBObject._awardNominations);
            Notify(_name.GetFirstName() + " " + _name.GetLastName() + " has been nominated for "
                + awardNomination.GetTitle() + " " + awardNomination.GetCategory() + " for the role of "
                + awardNomination.GetFeature().GetActingRole() + " in " + awardNomination.GetFeature().GetEntity().GetTitleName());
        }

        public void AddAwardWin(Award awardWin)
        {
            Person DBObject = GetMatchingObject();
            //            _awardWins.Add(awardWin);
            DBObject._awardWins.Add(awardWin);
            MultimediaDB.db.Store(DBObject._awardWins);
            Notify(_name.GetFirstName() + " " + _name.GetLastName() + " has won "
                + awardWin.GetTitle() + " " + awardWin.GetCategory() + " for the role of "
                + awardWin.GetFeature().GetActingRole() + " in " + awardWin.GetFeature().GetEntity().GetTitleName());
        }

        public void Notify(String notification)
        {
            _subscribers.ForEach(x => x.UpdateObservers(notification));
        }
    }
}
