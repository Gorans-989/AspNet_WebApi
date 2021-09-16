﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp.DomainModels.DbModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
