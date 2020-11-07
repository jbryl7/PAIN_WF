﻿using System;
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

        public long Index
        {
            get;
            set;
        }

        public DateTime BirthDate
        {
            get;
            set;
        }

        public Song( string name, long index, DateTime birthDate )
        {
            Name = name;
            Index = index;
            BirthDate = birthDate;
        }
    }
}