using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Episode
    {
        private int number;
        private int season;
        private List<Person> cast;
        private double rating;
        private Show show;
        

        public Episode(int number, int season, List<Person> cast, double rating, Show show)
        {
            this.number = number;
            this.season = season;
            this.cast = cast;
            this.rating = rating;
            this.show = show;
        }

        public Episode()
        {
            
        }

        
    }
}
