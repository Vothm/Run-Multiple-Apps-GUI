using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Run_Multiple_Apps_GUI
{
    class CreateExecutable
    {
        List<String> listOfApps = new List<string>();
        string filePath;
        string fileName;
        public CreateExecutable(List<String> listOfApps, String filePath, String fileName)
        {
            // Deep Copy
            foreach (string path in listOfApps)
            {
                this.listOfApps.Add(path);
            }

            this.filePath = filePath;
            this.fileName = fileName;
        }

        public void create()
        {
            string fullPath = System.IO.Path.Combine(this.filePath, this.fileName);
            if (!Directory.Exists(this.filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            // Verify the path that you have constructed.
            Console.WriteLine("Path to my file: {0}\n", filePath);

            // Check that the file doesn't already exist
            // DANGER: System.IO.File.Create will overwrite the file if it already exists
            // This could happen even with random file names, although it is unlikely
            try
            {
                // Check if file already exists. If yes, delete it.   
                if (System.IO.File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                AutoClosingMessageBox.Show("Creating file");
                // Create a new file 
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    sw.WriteLine("@echo off");
                    for(int i = 0; i < this.listOfApps.Count; i++)
                    {
                        sw.WriteLine("start \"\" \"" + this.listOfApps[i] + "\"");
                    }
                    AutoClosingMessageBox.Show("File made");
                }

                AutoClosingMessageBox.Show("Converting File...");
                File.Move(fullPath, Path.ChangeExtension(fullPath, ".bat"));

                AutoClosingMessageBox.Show("Removing temporary file");
                File.Delete(fullPath);
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show("error");
                Console.WriteLine(Ex.ToString());
            }
        }

    }
}
