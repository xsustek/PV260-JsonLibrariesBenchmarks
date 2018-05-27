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
    public class BigJsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Rootobject NewtonsoftJson_DeserializeMemory()
        {
            return JsonConvert.DeserializeObject<Rootobject>(JsonSampleString);
        }

        [Benchmark]
        public Rootobject NewtonsoftJson_DeserializeDisk()
        {
            return JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(jsonPath));
        }

        [Benchmark]
        public Rootobject NewtonsoftJson_DeserializeStream()
        {
            using (var stream = new StreamReader(jsonPath))
            using (var jsonReader = new JsonTextReader(stream))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Rootobject>(jsonReader);
            }
        }

        [Benchmark]
        public Rootobject Jil_DeserializeMemory()
        {
            return JSON.Deserialize<Rootobject>(JsonSampleString);
        }

        [Benchmark]
        public Rootobject Jil_DeserializeDisk()
        {
            return JSON.Deserialize<Rootobject>(File.ReadAllText(jsonPath));
        }
        [Benchmark]
        public Rootobject Jil_DeserializeStream()
        {
            using (var stream = new StreamReader(jsonPath))
            {
                return JSON.Deserialize<Rootobject>(stream);
            }

        }
    }
}