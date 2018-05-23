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
            string serviceName = "searchvm4yfvffnjpg2";

            string apiKey = "837072183089F75D110BDA8BE7D84E50";

            SearchServiceClient serviceClientApi = Helper.Initialize(serviceName, apiKey);
            ISearchIndexClient indexClientApi = serviceClientApi.Indexes.GetClient(Helper.IndexName);

            Uploader uploader = new Uploader();
            uploader.Upload(indexClientApi);

            Searcher searcher = new Searcher();

            Console.WriteLine("Search by name....\n");
            searcher.SearchDocuments(indexClientApi, "Maze Runner : The Death Cure");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search category for fantasy movies....\n");
            searcher.SearchDocuments(indexClientApi, "*", "Category eq 'Thriller'");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search for movies with a rating of 8.0 and over.......\n");
            searcher.SearchDocuments(indexClientApi, "*", "UserRating gt 8.0");

            //Console.WriteLine("Begin searching by ..... facet\n");
            List<string> facets = new List<string>();
            facets.Add("Category");
            //apiKey.SearchDocuments(indexClientApi, "*", null, facets);

            Console.ReadLine();

        }
    }
}
