using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMoviesAndTvShows
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "[SEARCH SERVICE NAME]";

            string apiKey = "[API KEY]";

            SearchServiceClient serviceClientApi = Helper.Initialize(serviceName, apiKey);
            ISearchIndexClient indexClientApi = serviceClientApi.Indexes.GetClient(Helper.IndexName);

            Uploader uploader = new Uploader();
            uploader.Upload(indexClientApi);

            Searcher searcher = new Searcher();

            Console.WriteLine("Search by name....\n");
            searcher.SearchDocuments(indexClientApi,"*", "Name eq 'Maze Runner : The Death Cure'");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search category for fantasy movies....\n");
            searcher.SearchDocuments(indexClientApi, "*", "Category eq 'Fantasy' and Type eq 'Movie'");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search for movies with a rating of 9.0 and over.......\n");
            searcher.SearchDocuments(indexClientApi, "*", "UserRating gt 9.0");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search for movies with a run time of 2.31 or less.....\n");
            searcher.SearchDocuments(indexClientApi, "*", "RunLength lt '2.32' and UserRating lt 9.0");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Show all movies.....");
            searcher.SearchDocuments(indexClientApi, "*", "Type eq 'Movie'");
            Console.WriteLine(string.Empty);


            Console.WriteLine("Show all tv shows.....");
            searcher.SearchDocuments(indexClientApi, "*", "Type eq 'TvShow' and Category ne 'Comedy'");
            Console.WriteLine(string.Empty);


            //Console.WriteLine("Begin searching by ..... facet\n");
            List<string> facets = new List<string>();
            facets.Add("Category");
            //apiKey.SearchDocuments(indexClientApi, "*", null, facets);

            Console.ReadLine();

        }
    }
}
