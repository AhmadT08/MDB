using System.Collections.Generic;

namespace MDB
{
    internal class Episode
    {
        public int Number { get; set; }

        public int Season { get; set; }

        public List<Person> Cast { get; set; }

        public double Rating { get; set; }

        public Show Show { get; set; }

        public Episode(int number, int season, List<Person> cast, double rating, Show show)
        {
            Number = number;
            Season = season;
            Cast = cast;
            Rating = rating;
            Show = show;
        }

        public Episode()
        {
        }


    }
}