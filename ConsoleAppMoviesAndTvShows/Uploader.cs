using ConsoleAppMoviesAndTvShows;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppMoviesAndTvShows
{
    public class Uploader
    {
        private List<MoviesAndTvShows> PrepareDocuments()
        {
            List<MoviesAndTvShows> moviesAndTvShowsDocuments = new List<MoviesAndTvShows>();

            MoviesAndTvShows m1 = new MoviesAndTvShows
            {
                Id = "1",
                Name = "The Lord Of The Rings : The Fellowship Of The Ring",
                Category = "Fantasy",
                Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                ReleaseDate = new DateTimeOffset(2001, 12, 19, 0, 0, 0, TimeSpan.Zero),
                RunLength = "2.58",
                UserRating = 9.5,
                Type = "Movie",

            };

            MoviesAndTvShows m2 = new MoviesAndTvShows
            {
                Id = "2",
                Name = "Maze Runner : The Death Cure",
                Category = "Action",
                Description = "Young hero Thomas embarks on a mission to find a cure for a deadly disease known as The Flare",
                ReleaseDate = new DateTimeOffset(2018, 1, 26, 0, 0, 0, TimeSpan.Zero),
                RunLength = "2.32",
                UserRating = 7.5,
                Type = "Movie",

            };

            MoviesAndTvShows m3 = new MoviesAndTvShows
            {
                Id = "3",
                Name = "The Hobbit : An Unexpected Journey",
                Category = "Fantasy",
                Description = "A reluctant Hobbit, Bilbo Baggins, sets out to the Lonely Mountain with a spirited group of dwarves to reclaim their mountain home, and the gold within it from the dragon Smaug.",
                ReleaseDate = new DateTimeOffset(2014, 7, 13, 0, 0, 0, TimeSpan.Zero),
                RunLength = "3.33",
                UserRating = 8.1,
                Type = "Movie",

            };

            MoviesAndTvShows m4 = new MoviesAndTvShows
            {
                Id = "4",
                Name = "The Bourne Identity",
                Category = "Thriller",
                Description = "A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and regain his memory.",
                ReleaseDate = new DateTimeOffset(2015, 1, 20, 0, 0, 0, TimeSpan.Zero),
                RunLength = "2.22",
                UserRating = 8.9,
                Type = "Movie",

            };

            MoviesAndTvShows t1 = new MoviesAndTvShows
            {
                Id = "5",
                Name = "Game Of Thrones",
                Category = "Fantasy",
                Description = "",
                ReleaseDate = new DateTimeOffset(2015, 1, 20, 0, 0, 0, TimeSpan.Zero),
                RunLength = "1.00",
                UserRating = 9.9,
                Type = "TvShow",

            };

            MoviesAndTvShows t2 = new MoviesAndTvShows
            {
                Id = "6",
                Name = "Lost",
                Category = "Mystery",
                Description = "",
                ReleaseDate = new DateTimeOffset(2015, 1, 20, 0, 0, 0, TimeSpan.Zero),
                RunLength = "55.0",
                UserRating = 10,
                Type = "TvShow",

            };

            MoviesAndTvShows t3 = new MoviesAndTvShows
            {
                Id = "7",
                Name = "The Walking Dead",
                Category = "Horror",
                Description = "",
                ReleaseDate = new DateTimeOffset(2015, 1, 20, 0, 0, 0, TimeSpan.Zero),
                RunLength = "52.0",
                UserRating = 8.7,
                Type = "TvShow",

            };

            MoviesAndTvShows t4 = new MoviesAndTvShows
            {
                Id = "8",
                Name = "The Simpsons",
                Category = "Comedy",
                Description = "",
                ReleaseDate = new DateTimeOffset(2015, 1, 20, 0, 0, 0, TimeSpan.Zero),
                RunLength = "30.0",
                UserRating = 5.6,
                Type = "TvShow",

            };
            moviesAndTvShowsDocuments.Add(m1);
            moviesAndTvShowsDocuments.Add(m2);
            moviesAndTvShowsDocuments.Add(m3);
            moviesAndTvShowsDocuments.Add(m4);

            moviesAndTvShowsDocuments.Add(t1);
            moviesAndTvShowsDocuments.Add(t2);
            moviesAndTvShowsDocuments.Add(t3);
            moviesAndTvShowsDocuments.Add(t4);


            return moviesAndTvShowsDocuments;

        }

        public void Upload(ISearchIndexClient indexClient)
        {
            try
            {
                var documents = PrepareDocuments();
                var batch = IndexBatch.Upload(documents);
                indexClient.Documents.Index(batch);

                Thread.Sleep(2000);
            }
            catch (IndexBatchException e)
            {
                Console.WriteLine($"Opps The Following index failed...\n { e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)}");

            }

        }
    }
}



