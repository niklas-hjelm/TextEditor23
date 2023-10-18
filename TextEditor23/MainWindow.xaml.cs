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
            var text = MainTextBox.Text;
            using var sw = new StreamWriter(_filePath);
            sw.Write(text);
        }

        private void OpenFileBtn_OnClick(object sender, RoutedEventArgs e)
        {
            using var sr = new StreamReader(_filePath);
            var text = sr.ReadToEnd();
            MainTextBox.Text = text;
        }
    }
}
