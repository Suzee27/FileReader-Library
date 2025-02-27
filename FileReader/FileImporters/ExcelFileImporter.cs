using ClosedXML.Excel;

namespace FileReader.FileImporters
{
    public class ExcelFileImporter : IFileImport<List<List<string>>>
    {
        public List<List<string>> ImportFile(string filePath)
        {
            var workbook = new XLWorkbook(filePath);

            var worksheetData = new List<List<string>>();

            foreach (var worksheet in workbook.Worksheets)
            {
                var rowData = new List<string>();
                foreach (var row in worksheet.RowsUsed())
                {
                    var cellData = new List<string>();
                    foreach (var cell in worksheet.CellsUsed())
                    {
                        cellData.Add(cell.GetValue<string>());
                    }
                    rowData.Add(string.Join(",", cellData));
                    //worksheetData.Add(rowData);
                }
                worksheetData.Add(rowData);
            }
            return worksheetData;
        }
    }

}
