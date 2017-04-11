using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDB
{
    class Award
    {
        public int Year { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public bool Win { get; set; }

        public bool Nomination { get; set; }

        public Feature Feature { get; set; }

        public Watchable Watchable { get; set; }

        public Award(int year, string category, string title, bool win, bool nomination, Feature feature)
        {
            Year = year;
            Category = category;
            Title = title;
            Win = win;
            Nomination = nomination;
            Feature = feature;
            Watchable = null;
        }

        public Award(int year, string category, string title, bool win, bool nomination, Watchable watchable)
        {
            Year = year;
            Category = category;
            Title = title;
            Win = win;
            Nomination = nomination;
            Feature = null;
            Watchable = watchable;
        }

        public Award()
        {

        }


    }
}
