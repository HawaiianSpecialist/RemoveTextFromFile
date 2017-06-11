using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveTextFromFile
{
    public class FileManager
    {
        // File Rename Method
        public bool renameFile(string sourceFolder, string textToRemove, string textToReplace)
        {
            bool result = false;
            string logName = Path.Combine(sourceFolder, DateTime.Now.ToString("yyyy-MM-dd") + "-rename.log");

            try
            {
                string[] files = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);

                // Gather a list of all files within the source folder
                foreach(string file in files)
                {

                    string newFileName = Path.GetFileName(file).Replace(textToRemove, textToReplace);
                    string newDestination = Path.Combine(Path.GetDirectoryName(file), newFileName);
                    // Move file if it doesn't exist
                    if(!File.Exists(newDestination))
                    {
                        // Remove unwanted text from file and move it to destination folder
                        File.Move(file, newDestination);

                        // Log renamed file to source directory
                        logRenamedFile(logName, file + " -> " + newDestination);

                        Console.WriteLine(DateTime.Now.ToString("hh:MM:ss tt ") + "[Renamed] " + newDestination);
                    }
                    else
                    {
                        Console.WriteLine("[Skipping] " + file);
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("[ERROR]: " + err.Message);
            }
            return result;
        }

        private void logRenamedFile(string path, string fileName)
        {
            File.AppendAllText(path, DateTime.Now.ToString("[yyyy-MM-dd hh:mm:ss tt] ") + fileName + Environment.NewLine);
        }
    }

}
