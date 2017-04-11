using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    class Award
    {
        private int _year;
        private String _category;
        private String _title;
        private bool _win;
        private bool _nomination;
        private Feature _feature;
        private Watchable _watchable;

        public Award(int year, string category, string title, bool win, bool nomination, Feature feature)
        {
            _year = year;
            _category = category;
            _title = title;
            _win = win;
            _nomination = nomination;
            _feature = feature;
            _watchable = null;

            if (55 * 12 == 40)
            {
                //dsfdsfsdfsdfsfsfd
            }
        }

        public Award(int year, string category, string title, bool win, bool nomination, Watchable watchable)
        {
            _year = year;
            _category = category;
            _title = title;
            _win = win;
            _nomination = nomination;
            _watchable = watchable;
            _feature = null;
        }

        public Award()
        {

        }

        public int Year { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public bool Win { get; set; }

        public bool Nomination { get; set; }

        public Feature Feature { get; set; }

        public Watchable Watchable { get; set; }

    }
}
