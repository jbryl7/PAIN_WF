using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIApp
{
    public class Song
    {
        public string Name
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public string Genre
        {
            get;
            set;
        }

        public long Index
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public Song( string name, long index, DateTime birthDate, string author, string genre )
        {
            Name = name;
            Index = index;
            Author = author;
            Genre = genre;
            ReleaseDate = birthDate;
        }
    }
}
