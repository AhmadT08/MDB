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
using System.IO;
using System.Drawing;

namespace MDB
{
    class Watchable
    {
        protected readonly int _ID;
        private List<Award> _awardNominations;
        private List<Award> _awardWins;
        private List<string> _genre;
        private List<Person> _mainCast;
        private string _mpaaRating;
        private string _synopsis;
        private string _productionStatus;
        private double _rating;
        private List<User> _subscribers;
        private string _titleName;
        private byte[] _poster;

        public Watchable(List<Award> awardNominations, List<Award> awardWins, List<string> genre,
                         List<Person> mainCast, string mpaaRating, string synopsis, string productionStatus, double rating,
                         List<User> subscribers, string titleName, Image poster)
        {
            _ID = MultimediaDB.db.QueryByExample(typeof(Movie)).Count + MultimediaDB.db.QueryByExample(typeof(Show)).Count + 1;
            _awardNominations = awardNominations;
            _awardWins = awardWins;
            _genre = genre;
            _mainCast = mainCast;
            _mpaaRating = mpaaRating;
            _synopsis = synopsis;
            _productionStatus = productionStatus;
            _rating = rating;
            _subscribers = subscribers;
            _titleName = titleName;
            _poster = imageToByteArray(poster);
        }

        public Watchable()
        {

        }

        public Watchable GetMatchingObject()
        {
            return new Watchable();
        }

        public static void Update(object x)
        {

        }

        public void Delete()
        {

        }

        public int GetID()
        {
            return _ID;
        }

        public List<Award> GetAwardNominations()
        {
            return _awardNominations;
        }

        public void AddAwardNomination(Award awardNomination)
        {
            Watchable DBObject = GetMatchingObject();
            _awardNominations.Add(awardNomination);
            DBObject._awardNominations.Add(awardNomination);
            Update(DBObject);
        }

        public List<Award> GetAwardWins()
        {
            return _awardWins;
        }

        public void AddAwardWin(Award awardWin)
        {
            Watchable DBObject = GetMatchingObject();
            _awardWins.Add(awardWin);
            DBObject._awardWins.Add(awardWin);
            Update(DBObject);
        }

        public List<string> GetGenre()
        {
            return _genre;
        }

        public void SetGenre(List<string> genre)
        {
            Watchable DBObject = GetMatchingObject();
            _genre = genre;
            DBObject._genre = genre;
            Update(DBObject);
        }

        public List<Person> GetMainCast()
        {
            return _mainCast;
        }

        public void SetMainCast(List<Person> mainCast)
        {
            Watchable DBObject = GetMatchingObject();
            _mainCast = mainCast;
            DBObject._mainCast = mainCast;
            Update(DBObject);
        }

        public void AddToMainCast(Person cast)
        {
            Watchable DBObject = GetMatchingObject();
            _mainCast.Add(cast);
            DBObject._mainCast.Add(cast);
            Update(DBObject);
        }

        public string GetMpaaRating()
        {
            return _mpaaRating;
        }

        public void SetMpaaRating(string mpaaRating)
        {
            Watchable DBObject = GetMatchingObject();
            _mpaaRating = mpaaRating;
            DBObject._mpaaRating = mpaaRating;
            Update(DBObject);
        }

        public string GetSynopsis()
        {
            return _synopsis;
        }

        public void SetSynopsis(string synopsis)
        {
            Watchable DBObject = GetMatchingObject();
            _synopsis = synopsis;
            DBObject._synopsis = synopsis;
            Update(DBObject);
        }

        public string GetProductionStatus()
        {
            return _productionStatus;
        }

        public void SetProductionStatus(string productionStatus)
        {
            Watchable DBObject = GetMatchingObject();
            _productionStatus = productionStatus;
            DBObject._productionStatus = productionStatus;
            Update(DBObject);
        }

        public double GetRating()
        {
            return _rating;
        }

        public void SetRating(double rating)
        {
            Watchable DBObject = GetMatchingObject();
            _rating = rating;
            DBObject._rating = rating;
            Update(DBObject);
        }

        public List<User> GetSubscribers()
        {
            return _subscribers;
        }

        public void SetSubscribers(List<User> subscribers)
        {
            Watchable DBObject = GetMatchingObject();
            _subscribers = subscribers;
            DBObject._subscribers = subscribers;
            Update(DBObject);
        }

        public void AddSubscriber(User sub)
        {
            Watchable DBObject = GetMatchingObject();
            _subscribers.Add(sub);
            DBObject._subscribers.Add(sub);
            Update(DBObject);
        }

        public void RemoveSubscriber(User sub)
        {
            Watchable DBObject = GetMatchingObject();
            _subscribers.Remove(sub);
            DBObject._subscribers.Remove(sub);
            Update(DBObject);
        }

        public string GetTitleName()
        {
            return _titleName;
        }

        public void SetTitleName(string titleName)
        {
            Watchable DBObject = GetMatchingObject();
            _titleName = titleName;
            DBObject._titleName = titleName;
            Update(DBObject);
        }

        public void setPoster(Image poster)
        {
            Watchable DBObject = GetMatchingObject();
            _poster = imageToByteArray(poster);
            DBObject._poster = imageToByteArray(poster);
            Update(DBObject);
        }

        public Image getPoster()
        {
            return byteArrayToImage(_poster);
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
}
