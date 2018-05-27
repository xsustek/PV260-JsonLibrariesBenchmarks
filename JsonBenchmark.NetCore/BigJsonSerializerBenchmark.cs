using System.IO;
using System.Text;
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
    public class BigJsonSerializersBenchmarks : JsonBenchmarkBase
    {
        private readonly Rootobject data;

        public BigJsonSerializersBenchmarks()
        {
            data = JsonConvert.DeserializeObject<Rootobject>(bigJsonString);
        }

        [Benchmark]
        public string NewtonsoftJson_SerializeMemory()
        {
            return JsonConvert.SerializeObject(data);
        }

        [Benchmark]
        public string Jil_SerializeMemory()
        {
            return JSON.Serialize(data);
        }
    }
}