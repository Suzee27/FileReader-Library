using DocumentFormat.OpenXml.Packaging;

namespace FileReader.FileImporters
{
    public class WordFileImporter : IFileImport<string>
    {
        public string ImportFile(string filePath)
        {
            var doc = WordprocessingDocument.Open(filePath, false);
            var body = doc.MainDocumentPart?.Document.Body;
            return body.InnerText;
        }
    }

}
