using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMoviesAndTvShows
{
    public class MoviesAndTvShows
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description {get; set;}
        public DateTimeOffset ReleaseDate { get; set; }
        public string RunLength { get; set; }
        public double? UserRating { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nCategory: {Category}\nDescription: {Description}\nRelease Date: {ReleaseDate}\nRun Length: {RunLength}\nUser Rating: {UserRating}\n";
        }
    }
}
