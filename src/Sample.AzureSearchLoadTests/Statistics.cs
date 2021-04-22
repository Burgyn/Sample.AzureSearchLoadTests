using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Sample.AzureSearchLoadTests
{
    public class Statistics
    {
        private int _actualBatch = 0;
        private int _totalCount = 0;
        private List<Batch> _batches = new List<Batch>();

        public Statistics(int initTotalCount)
        {
            _totalCount = initTotalCount;
        }

        public void Add(int actualBatch)
        {
            _actualBatch += actualBatch;
            _totalCount += actualBatch;
        }

        public Batch AddIndexedCount(int indexedCount)
        {
            Batch batch = new(DateTime.Now, _totalCount, _actualBatch, indexedCount);

            _batches.Add(batch);
            _actualBatch = 0;

            return batch;
        }

        public void Dump()
        {
            using var writer = new StreamWriter("result.csv");
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" });

            csv.WriteRecords(_batches);
        }

        public record Batch(DateTime Time, int TotalUploadedCount, int ActualUploadedCount, int TotalIndexedCount)
        {
            public int MissingDataCount => TotalUploadedCount - TotalIndexedCount;

            public int ActualIndexedCount => ActualUploadedCount - MissingDataCount;

            public string Dump()
                => $"Total uploaded count: {TotalUploadedCount}, Total indexed count: {TotalIndexedCount}, Actual uploaded count: {ActualUploadedCount}, Actual indexed count: {ActualIndexedCount}, Missing data count {MissingDataCount}";
        }
    }
}
