using System.Collections.Generic;

namespace MDB
{
    internal class Episode
    {
        private int _number;
        private int _season;
        private List<Person> _cast;
        private double _rating;
        private Show _show;

        public Episode(int number, int season, List<Person> cast, double rating, Show show)
        {
            _number = number;
            _season = season;
            _cast = cast;
            _rating = rating;
            _show = show;
        }

        public Episode()
        {
        }

        public int Number { get; set; }

        public int Season { get; set; }

        public List<Person> Cast { get; set; }

        public double Rating { get; set; }

        public Show Show { get; set; }
    }
}