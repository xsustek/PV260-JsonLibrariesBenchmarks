using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using Jil;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    [ClrJob(true), CoreJob]
    [RPlotExporter, RankColumn, MemoryDiagnoser]
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
            return JsonConvert.DeserializeObject<Root>(File.ReadAllText(jsonPath));
        }

        [Benchmark]
        public Root NewtonsoftJson_DeserializeStream()
        {
            using (var stream = new StreamReader(jsonPath))
            using (var jsonReader = new JsonTextReader(stream))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Root>(jsonReader);
            }
        }

        [Benchmark]
        public Root Jil_DeserializeMemory()
        {
            return JSON.Deserialize<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root Jil_DeserializeDisk()
        {
            return JSON.Deserialize<Root>(File.ReadAllText(jsonPath));
        }
        [Benchmark]
        public Root Jil_DeserializeStream()
        {
            using (var stream = new StreamReader(jsonPath))
            {
                return JSON.Deserialize<Root>(stream);
            }
            
        }
    }
}