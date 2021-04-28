using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Thinkershare.Markdown.Test.TestData
{
    public static class TestData
    {
        public static IEnumerable<object[]> BeResultWhenParseFromOuter()
        {
            const string path = "../../../TestData";
            var directory = new DirectoryInfo(path);

            var data = (from fileInfo in directory.GetFiles().Where(item => item.Name.EndsWith(".md"))
                        let outputFileName = fileInfo.Name.Replace(".md", ".html")
                        let outputPath = Path.Combine(directory.FullName, outputFileName)
                        let inputContent = File.ReadAllText(fileInfo.FullName)
                        let outputContent = File.ReadAllText(outputPath)
                        select new object[] { inputContent, outputContent }).ToList();

            return data;
        }
    }
}
