using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using TextJSONCommentTest.Models;

namespace TextJSONCommentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("TextJSONCommentTest.Data.sampleData.jsonc");

            //read test
            using var sr = new StreamReader(stream);
            string jsonString = sr.ReadToEnd();
            Console.WriteLine(jsonString);


            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            //deserialize 
            SampleData sampleData = System.Text.Json.JsonSerializer.Deserialize<SampleData>(jsonString, options);

            //deserialize test
            Console.WriteLine(sampleData.FirstName);
        }
    }
}
