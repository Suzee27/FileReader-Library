using System.Text;

namespace FileReader
{
    public interface IFileImporter<T>
    {
         T ImportFile(string filePath);
    }

}
