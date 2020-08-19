using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;

namespace Run_Multiple_Apps_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<String> pathList = new List<string>(1);
        List<String> applicationNames = new List<string>(5);

        private string savePath;
        private string fileName;
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("System Initialized");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (applicationNames.Any() && !string.IsNullOrEmpty(savePath)) {
                if (!string.IsNullOrEmpty(fileName))
                {
                    var message = string.Join(Environment.NewLine, pathList.ToArray());
                    System.Windows.Forms.MessageBox.Show("The paths that you have selected are \n" + message);
                    CreateExecutable createFile = new CreateExecutable(pathList, savePath, fileName);
                    createFile.create();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please select a file name along with the path");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please pick at least one application or a filepath");
            }
        }

        private void App_Select_Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".exe";
            dlg.Filter = "All Files (*.*) | *.*";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                pathList.Add(filename);
                applicationNames.Add(dlg.SafeFileName);
            }

            SelectedText.Text = string.Join(Environment.NewLine, applicationNames.ToArray());
        }

        private void Select_Path_Button_Click(object sender, RoutedEventArgs e)
        {
            savePath = null;
            Current_Path.Text = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                savePath = System.IO.Path.GetDirectoryName(sfd.FileName);
            }
            fileName = System.IO.Path.GetFileName(sfd.FileName);

            Current_Path.Text = savePath + "\\" + fileName;
        }


        private void Clear_Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < applicationNames.Count; i++)
            {
                applicationNames.RemoveAt(i);
            }
            SelectedText.Text = "";
        }
    }
}
