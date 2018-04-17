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
        public string title;
        public string image_path;
        List<int> platforms = new List<int>();
        
        public LibraryMovie(int id, string title, string path)
        {
            this.id = id;
            this.title = title;
            this.image_path = path;
        }

        public LibraryMovie()
        {
                
        }

    }
}
