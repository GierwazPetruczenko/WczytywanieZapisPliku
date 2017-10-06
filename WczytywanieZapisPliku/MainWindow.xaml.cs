using System;
using System.Collections.Generic;
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
using System.IO;

namespace WczytywanieZapisPliku
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PoleTekstowe.Text = "";
        }



        

        private void OpenBTN_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();// można też bool?
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("Windows-1250"));
                PoleTekstowe.AppendText(sr.ReadToEnd());
                sr.Close();
            }
            
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlgSave = new Microsoft.Win32.SaveFileDialog();
            dlgSave.FileName = "select file...";
            dlgSave.DefaultExt = ".txt";
            dlgSave.Filter= "Text documents (.txt)|*.txt";
            bool? result = dlgSave.ShowDialog();
            if (result == true)
            {
                string filename = dlgSave.FileName;
                if (!(File.Exists(filename)))
                    File.CreateText(filename);
                //if (File.Exists(Directory.GetCurrentDirectory()+'/' + filename))
                //    PoleTekstowe.Text = "Niczem";
                //string pathOfFilename = System.IO.Path.GetDirectoryName(filename);
                StreamWriter sr = new StreamWriter(filename);
                sr.Write(PoleTekstowe.Text);//zapisanie do bufora pamięci nie do pliku
                sr.Close();//czyszczenie bufora zpais do pliku
            }
        }
    }
}
