using System.IO;
using System.Text;
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
    public class JsonSerializersBenchmarks : JsonBenchmarkBase
    {
        private readonly Root data;

        public JsonSerializersBenchmarks()
        {
            data = JsonConvert.DeserializeObject<Root>(base.JsonSampleString);
        }

        [Benchmark]
        public string NewtonsoftJson_SerializeMemory()
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}