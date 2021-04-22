using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.AzureSearchLoadTests
{
    class AzureSearchHelper
    {
        private readonly string _prefix;
        private readonly string _apiKey;
        private readonly SearchClient _searchClient;

        public AzureSearchHelper(string prefix, string apiKey)
        {
            _prefix = prefix;
            _apiKey = apiKey;

            var indexClient = CreateSearchIndexClient(prefix, apiKey);
            _searchClient = indexClient.GetSearchClient("ordersindex");
        }

        private static SearchIndexClient CreateSearchIndexClient(string prefix, string apiKey)
        {
            string searchServiceEndPoint = $"https://{prefix}-search-test-acs.search.windows.net";

            var indexClient = new SearchIndexClient(new Uri(searchServiceEndPoint), new AzureKeyCredential(apiKey));

            return indexClient;
        }

        public async Task UploadDocumentsAsync(IEnumerable<Order> documents)
        {
            var batch = IndexDocumentsBatch.Upload(documents);

            await _searchClient.IndexDocumentsAsync(batch);
        }

        public async Task<int> GetDocumentsCountAsync()
        {
            string url = $"https://{_prefix}-search-test-acs.search.windows.net/indexes/ordersindex/docs/$count?api-version=2020-06-30-Preview";
            string value = await url
                .WithHeader("Content-Type", "application/json")
                .WithHeader("api-key", _apiKey)
                .GetStringAsync();

            return int.Parse(value);
        }
    }
}
