using System;
using System.Collections.Generic;
using System.IO;

namespace Hashor.App
{
    public class IngestFile
    {

        private string filePath;
        
        IngestFile(string path)
        {
            filePath = path;
        }

        public string GetFileAsText()
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
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