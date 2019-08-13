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
        string[] SearchedFile;
        public MainWindow()
        {
            InitializeComponent();
        }

        #region open 클릭
        private void OpenClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog Folderopen = new FolderBrowserDialog();
            Folderopen.Description = "폴더 검색";
            Folderopen.ShowDialog();
            Folderselect = Folderopen.SelectedPath;
            FileEntries = Directory.GetFiles(Folderselect);
        }
        #endregion

        #region find 클릭
        private void FindClick(object sender, RoutedEventArgs e)
        {
            foreach (string list in FileEntries)
            {
                if (System.IO.Path.GetExtension(list) == ".txt")
                {
                    string view = "";
                    string values = "";
                    string fileread = File.ReadAllText(list);
                    int FindNo_Value = FindNo(fileread, ref values);
                    Console.WriteLine(FindNo_Value);
                    Console.WriteLine(values);
                    if (FindNo_Value > 0)
                    {
                        ListView.Items.Add(list);
                    }
                }
            }
        }
        #endregion

        #region 전화번호 탐색 함수
        public int FindNo(string input, ref string values)
        {
            string[] patterns =
            {
                @"(^|\W)01[01]\d{7,8}(\W|$)",
                @"(^|\W)01[01]-\d{3,4}-\d{4}(\W|$)"
            };

            int count = 0;

            foreach ( string pattern in patterns)
            {
                System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(input, pattern);

                foreach (System.Text.RegularExpressions.Match m in matches)
                {
                    ++count;
                    values += m + "\n";
                }
            }
            return count;
        }
        #endregion

        #region 리스트 선택
        private void List_select(object sender, MouseButtonEventArgs e)
        {
            TextArea.Text = "";
            System.Windows.Controls.ListView list = sender as System.Windows.Controls.ListView;
            string convert = list.SelectedItem as string;
            string value = File.ReadAllText(convert);
            TextArea.Text = value;
        }
        #endregion
    }
}
