using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Resources;
using Run_Multiple_Apps_GUI.Properties;
using System.Diagnostics;
using System.Reflection;
using IWshRuntimeLibrary;
using System.Threading;

namespace Run_Multiple_Apps_GUI
{
    class CreateExecutable
    {
        private List<String> listOfApps = new List<string>();
        private string filePath;
        private string fileName;
        public CreateExecutable(List<String> listOfApps, String filePath, String fileName)
        {
            // Deep Copy
            foreach (string path in listOfApps)
            {
                this.listOfApps.Add(path);
            }

            this.filePath = filePath;
            this.fileName = fileName;
            Create();
        }
        public void Create()
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
                    System.IO.File.Delete(fullPath);
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

                //AutoClosingMessageBox.Show("Converting File...");
                System.IO.File.Move(fullPath, Path.ChangeExtension(fullPath, ".bat"));
                //AutoClosingMessageBox.Show("Removing temporary file");
                System.IO.File.Delete(fullPath);
                
                
                try {
                    //"Run_Multiple_Apps_GUI.Resources.Bat2ExeIEXP.bat"

                    //string batFileName = "Bat2ExeIEXP.bat";

                    var assembly = Assembly.GetExecutingAssembly();
                    //Getting names of all embedded resources
                    var allResourceNames = assembly.GetManifestResourceNames();
                    //Selecting first one. 
                    var resourceName = allResourceNames[2];
                    var pathToFile = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) +
                                      resourceName;
                    using (var stream = assembly.GetManifestResourceStream(resourceName))
                    using (var fileStream = System.IO.File.Create(pathToFile))
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(fileStream);
                    }
                    string destinationFile = System.IO.Path.Combine(filePath, resourceName);
                    System.IO.File.Move(pathToFile, destinationFile);
                    ProcessStartInfo processInfo;
                    Process process;

                    processInfo = new ProcessStartInfo(resourceName);
                    processInfo.Arguments = $"{fileName}.bat {fileName}.exe";
                    processInfo.WorkingDirectory = filePath;
                    processInfo.CreateNoWindow = true;
                    processInfo.UseShellExecute = false;
                    process = Process.Start(processInfo);
                    process.WaitForExit();
                    int exitCode = process.ExitCode;
                    process.Close();

                    System.IO.File.Delete(destinationFile);
                    System.IO.File.Delete(fullPath);
                    System.IO.File.Delete($"{filePath}\\{fileName}.bat");

                    Thread.Sleep(3000);
                    CreateShortcut();
                } catch (Exception Ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error");
                    System.Diagnostics.Debug.WriteLine(Ex.ToString());
                }


            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show("error");
                Console.WriteLine(Ex.ToString());
            }
        }

        public void CreateShortcut()
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(filePath + $@"\{fileName}.lnk");
            shortcut.Description = "Shortcut to run multiple things at once";
            shortcut.WorkingDirectory = filePath;
            shortcut.TargetPath = filePath + $@"\{fileName}.exe";
            shortcut.Save();
            AutoClosingMessageBox.Show("Place the shortcut file anywhere and leave the .exe file");
        }

    }
}
