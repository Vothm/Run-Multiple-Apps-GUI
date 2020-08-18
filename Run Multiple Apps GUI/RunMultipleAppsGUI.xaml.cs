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


namespace Run_Multiple_Apps_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<String> pathList = new List<string>(5);
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
            var message = string.Join(Environment.NewLine, pathList.ToArray());
            System.Windows.Forms.MessageBox.Show("The paths that you have selected is \n" + message);
            CreateExecutable createFile = new CreateExecutable(pathList, savePath, fileName);
            createFile.create();
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                savePath = System.IO.Path.GetDirectoryName(sfd.FileName);
            }
            fileName = System.IO.Path.GetFileName(sfd.FileName);

            Current_Path.Text = savePath + fileName;
        }
    }
}
