using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace TextEditor23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _filePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            var dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TextDemo");
            Directory.CreateDirectory(dirPath);


            _filePath = Path.Combine(dirPath, "demo.txt");
        }

        private void SaveFileBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            if (saveFileDlg.ShowDialog() == true)
            {
                using var stream = new FileStream(saveFileDlg.FileName, FileMode.Create);
                var text = new TextRange(MainTextBox.Document.ContentStart, MainTextBox.Document.ContentEnd);
                text.Save(stream, DataFormats.Text);
            }
        }

        private void OpenFileBtn_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            if (openFileDlg.ShowDialog() == true)
            {
                using var sr = new StreamReader(openFileDlg.FileName);
                var text = sr.ReadToEnd();
                //MainTextBox.Document = text;
            }
        }

        private void ToggleBoldBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (ToggleBoldBtn.IsChecked == true)
            {
                MainTextBox.FontWeight = FontWeights.ExtraBold;
            }
            else
            {
                MainTextBox.FontWeight = FontWeights.Normal;

            }
        }
    }
}
