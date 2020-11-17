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
        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public Song( string name, DateTime birthDate, string author, string genre )
        {
            Name = name;
            Author = author;
            Genre = genre;
            ReleaseDate = birthDate;
        }
    }
}
