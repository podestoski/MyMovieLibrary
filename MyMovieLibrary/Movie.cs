using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieLibrary
{
    class Movie
    {
        public string title;
        public string platform;

        public Movie(string title, string platform)
        {
            this.title = title;
            this.platform = platform;
        }
    }
}
