namespace FileReader.FileImporters
{
    public class TxtFileImporter : IFileImport<List<string>>
    {
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
