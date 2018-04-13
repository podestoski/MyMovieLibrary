using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieLibrary
{
    class MovieVideosRootResult
    {
        public int id;
        public List<MovieVideosResult> results;
    }

    class MovieVideosResult
    {
        public string id;
        public string iso_639_1;
        public string iso_3166_1;
        public string key;
        public string name;
        public string site;
        public int size;
        public string type;
    }
}
