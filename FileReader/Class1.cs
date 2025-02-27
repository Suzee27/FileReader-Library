using System.Text;

namespace FileReader
{
    public interface IFileImport<T>
    {
         T ImportFile(string filePath);
    }

}
