using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    [ClrJob, CoreJob]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_DeserializeMemory()
        {
            return JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root NewtonsoftJson_DeserializeDisk()
        {
            return JsonConvert.DeserializeObject<Root>(File.ReadAllText(path));
        }

        [Benchmark]
        public Root NewtonsoftJson_DeserializeStream()
        {
            using (var stream = new StreamReader(path))
            using (var jsonReader = new JsonTextReader(stream))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Root>(jsonReader);
            }
        }
    }
}