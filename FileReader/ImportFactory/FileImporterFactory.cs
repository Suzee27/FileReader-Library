using FileReader.ImportInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.ImportFactory
{
    public class FileImporterFactory
    {
        private readonly List<Type> importerTypes;

        public FileImporterFactory()
        {
                importerTypes = new List<Type>();
            var assembly = Assembly.GetExecutingAssembly();
            importerTypes.AddRange(assembly.GetTypes()
                .Where(t => typeof(IFileImporter).IsAssignableFrom(t)
                        && !t.IsInterface && !t.IsAbstract));
        }

        public IFileImporter? CreateFileImporter(string filePath)
        {
            var importerType = importerTypes.FirstOrDefault(t =>
            {
                var importerInstance = Activator.CreateInstance(t) as IFileImporter;
                return importerInstance != null && importerInstance.CanImport(filePath);
            });

            return importerType == null
                ? throw new ArgumentException($"Unsupported file type: {Path.GetExtension(filePath)}")
                : Activator.CreateInstance(importerType) as IFileImporter;
        }
    }
}
