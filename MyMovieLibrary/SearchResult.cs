using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieLibrary
{
    class SearchMovieRootResult
    {
        public int page;
        public int total_results;
        public int total_pages;
        public List<SearchMovieResult> results;
    }

    class SearchMovieResult
    {
        public int vote_count;
        public int id;
        public bool video;
        public decimal vote_average;
        public string title;
        public decimal popularity;
        public string poster_path;
        public string original_language;
        public string original_title;
        public List<int> genre_ids;
        public string backdrop_path;
        public bool adult;
        public string overview;
        public string release_date;
    }    
}
