using CsvHelper;
using FileReader.ImportInterface;
using System.Globalization;

namespace FileReader.FileImporters
{
    public class CsvFileImporter : IFileImporter<List<string>>
    {
        public bool CanImport(string filePath) => filePath.EndsWith(".csv");

        public List<string> ImportFile(string filePath)
        {
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<string>();
            return (List<string>)records;
        }
    }

}
