using FileReader.ImportInterface;

namespace FileReader.FileImporters
{
    public class PdfFileImporter : IFileImporter<List<string>>
    {
        public bool CanImport(string filePath) => filePath.EndsWith(".pdf");

        public List<string> ImportFile(string filePath)
        {
            var texts = new List<string>();
            var pdf = new PdfDocument(filePath);

            foreach (var page in pdf.Pages)
            {
                string pageTexts = pdf.ExtractTextFromPage(page.PageIndex);
                texts.Add(pageTexts);

                var images = pdf.ExtractImagesFromPage(page.PageIndex);
                int count = 1;
                if (images != null)
                    foreach (var image in images)
                    {
                        image.SaveAs($"{filePath}_image{count}.jpg");
                        count++;
                    }
            }
            return texts;
        }
    }

}
