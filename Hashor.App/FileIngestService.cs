using System;
using static System.Console;
using System.IO;
using System.IO.Abstractions;


namespace Hashor.App
{
    public class FileIngestService
    {
        private string filePath;
        private readonly IFileSystem _fileSystem;

        public FileIngestService(string path) : this(path, new FileSystem())
        {
        }

        public FileIngestService(string path, IFileSystem fileSystem)
        {
            filePath = path;
            _fileSystem = fileSystem;
        }


        public bool FileExists(string path)
        {
            if (!_fileSystem.File.Exists(path))
            {
                WriteLine($"ERROR: File `{path}` does not exist");
                return false;
            }

            return true;
        }

        public string GetFileAsText()
        {
            try
            {
                return _fileSystem.File.ReadAllText(filePath);
            }
            catch (FileNotFoundException e)
            {
                WriteLine(e);
                throw;
            }

            catch (FileLoadException e)
            {
                WriteLine(e);
                throw;
            }
        }

        public string[] GetFileLinesAsList()
        {
            try
            {
                return _fileSystem.File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
        }
    }
}