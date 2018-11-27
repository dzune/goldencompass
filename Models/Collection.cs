using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace theMovieDB.Models
{
    public class Cast
    {
        public string name { get; set; }
        public string character { get; set; }
    }

    public class Movies
    {
        public string id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string vote_average { get; set; }
        public string poster_path { get; set; }
   
    }

}