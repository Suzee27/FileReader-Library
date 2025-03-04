using FileReader.ImportInterface;

namespace FileReader.FileImporters
{
    public class TxtFileImporter : IFileImporter<List<string>>
    {
        public bool CanImport(string filePath) => filePath.EndsWith(".txt");

        public List<string> ImportFile(string filePath)
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            return lines;
        }
    }

}
