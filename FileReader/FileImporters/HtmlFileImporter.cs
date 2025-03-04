using FileReader.ImportInterface;
using HtmlAgilityPack;

namespace FileReader.FileImporters
{
    public class HtmlFileImporter : IFileImporter<string>
    {
        public bool CanImport(string filePath) => filePath.EndsWith(".html");

        public string ImportFile(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return content;
        }

        public List<string> ImportFile(string filePath, string tagName)
        {
            var doc = new HtmlDocument();
            doc.Load(filePath);

            var nodes = doc.DocumentNode.SelectNodes("//" + tagName);
            var nodeTexts = new List<string>();
            foreach (var node in nodes)
            {
                nodeTexts.Add(node.InnerText);
            }
            return nodeTexts;
        }
    }

}
