using ShellProgressBar;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.AzureSearchLoadTests
{
    static class LoadTest
    {
        public static async Task RunAsync(string apiKey, string prefix, int iterationCount)
        {
            var azureSearch = new AzureSearchHelper(prefix, apiKey);
            var statistics = new Statistics(await azureSearch.GetDocumentsCountAsync());
            var options = new ProgressBarOptions
            {
                ProgressBarOnBottom = true,
                BackgroundCharacter = '\u2593'
            };
            using var pbar = new ProgressBar(iterationCount, "AZURE Search load test", options);

            for (int i = 0; i < iterationCount; i++)
            {
                pbar.Tick();
                int count = DataGenerator.RandomCount();
                var documents = DataGenerator.GenerateDocuments(count);
                statistics.Add(count);
                await azureSearch.UploadDocumentsAsync(documents);

                Thread.Sleep(TimeSpan.FromSeconds(1));

                var batch = statistics.AddIndexedCount(await azureSearch.GetDocumentsCountAsync());
                pbar.WriteLine(batch.Dump());
            }

            statistics.Dump();
        }
    }
}
