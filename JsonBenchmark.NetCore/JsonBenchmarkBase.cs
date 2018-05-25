using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";
        protected string JsonSampleString;
        protected string path;

        protected JsonBenchmarkBase()
        {
            path = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
            JsonSampleString = File.ReadAllText(path);
        }
    }
}
