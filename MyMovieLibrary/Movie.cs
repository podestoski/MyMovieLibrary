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
        public Platform platform;
        public int movie_id;

        public Movie(string title, Platform platform)
        {
            this.title = title;
            this.platform = platform;
        }

        public enum Platform
        {
            iTunes,
            Google_Play,
            Xbox,
            Playstation,
            Blu_ray,
            DVD
        }
    }
}
