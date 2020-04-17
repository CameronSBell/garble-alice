using System.IO;

namespace TextFilter
{
    public class FileReader : IFileReader
    {
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string ReadFile()
        {
            if (File.Exists(_path))
            {
                return File.ReadAllText(_path);
            }
            else
            {
                throw new FileNotFoundException($"The specified file '{_path}' does not exist or cannot be accessed. Please try again.");
            }
        }
    }
}
