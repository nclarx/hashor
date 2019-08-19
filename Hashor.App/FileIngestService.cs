using System;
using System.IO;


namespace Hashor.App
{
    public class FileIngestService
    {
        private string filePath;

        public FileIngestService(string path)
        {
            filePath = path;
        }

        public string GetFileAsText()
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }

            catch (FileLoadException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string[] GetFileLinesAsList()
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}