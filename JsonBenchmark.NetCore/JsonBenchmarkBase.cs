using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";
        protected string JsonSampleString;
        protected string jsonPath;

        protected string bigJsonPath;
        protected string bigJsonString;

        protected JsonBenchmarkBase()
        {
            bigJsonPath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "generated.json");
            bigJsonString = File.ReadAllText(bigJsonPath);
            jsonPath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
            JsonSampleString = File.ReadAllText(jsonPath);
        }
    }
}
