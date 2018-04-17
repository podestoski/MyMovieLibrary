using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieLibrary
{
    public class LibraryMovie
    {
        public int id;
        public int idMovie;
        public string title;
        public string image_path;
        public List<string> platforms = new List<string>();

        public LibraryMovie()
        {}
        
        public LibraryMovie(int id, int idMovie, string title, string path)
        {
            this.id = id;
            this.idMovie = idMovie;
            this.title = title;
            this.image_path = path;
        }
    }
}
