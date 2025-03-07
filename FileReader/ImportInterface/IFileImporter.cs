namespace FileReader.ImportInterface
{
    public interface IFileImporter<T> : IFileImporter
    {
        new T ImportFile(string filePath);

        object IFileImporter.ImportFile(string filePath) => ImportFile(filePath);
    }

    public interface IFileImporter
    {
        bool CanImport(string filePath);
        object ImportFile(string filePath);
    }

}
