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
using System.Windows.Forms;
using System.IO;

namespace Personal_Information_Finder
{
    
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string Folderselect = "";
        string[] FileEntries;
        public MainWindow()
        {
            InitializeComponent();
        }

        private string OpenClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog Folderopen = new FolderBrowserDialog();
            Folderopen.Description = "폴더 검색";
            Folderopen.ShowDialog();
            Folderselect = Folderopen.SelectedPath;
            FileEntries = Directory.GetFiles(Folderselect);
            //폴더엔트리 값들을 리스트뷰에 집어넣음//
        }

        private void FindClick(object sender, RoutedEventArgs e)
        {
            foreach(string list in FileEntries)
        }
    }
}
