using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMoviesAndTvShows
{
    public class Helper
    {
        public const string IndexName = "moviesandtvshows";

        public static SearchServiceClient Initialize(string serviceName, string apiKey)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));
            DeleteIfIndexExists(serviceClient);
            CreateIndex(serviceClient);

            return serviceClient;
        }

        private static void CreateIndex(SearchServiceClient client)
        {
            var IndexDefination = new Index()
            {
                Name = IndexName,
                Fields = new[]
                {
                    new Field("Id", DataType.String)                        { IsKey = true },
                    new Field("Name", DataType.String)                      { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("Category", DataType.String)                  { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("Description", DataType.String)               { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("ReleaseDate", DataType.DateTimeOffset)       { IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("RunLength", DataType.String)                 { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                     new Field("UserRating", DataType.Double)               { IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},

                }
            };

            client.Indexes.Create(IndexDefination);

        }

        private static void DeleteIfIndexExists(SearchServiceClient client)
        {
            if (client.Indexes.Exists(IndexName))
            {
                client.Indexes.Delete(IndexName);
            }
        }
    }
}
