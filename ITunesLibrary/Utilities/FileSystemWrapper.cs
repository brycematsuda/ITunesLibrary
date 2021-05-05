using System.IO;

namespace ITunesLibrary.Utilities
{
    public interface IFileSystem
    {
        string ReadTextFromFile(string fileLocation);
    }

    public class FileSystemWrapper : IFileSystem
    {
        public string ReadTextFromFile(string fileLocation)
        {
            return File.ReadAllText(fileLocation);
        }
    }
}