using DocumentFormat.OpenXml.Packaging;
using FileReader.ImportInterface;

namespace FileReader.FileImporters
{
    public class WordFileImporter : IFileImporter<string>
    {
        public bool CanImport(string filePath) => filePath.EndsWith(".docx");

        public string ImportFile(string filePath)
        {
            var doc = WordprocessingDocument.Open(filePath, false);
            var body = doc.MainDocumentPart?.Document.Body;
            return body.InnerText;
        }
    }

}
