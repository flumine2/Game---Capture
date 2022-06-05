using Game___Capture.SaveResults;
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
using System.Windows.Shapes;

namespace Game___Capture.views
{
    /// <summary>
    /// Interaction logic for StartExitTopListWindow.xaml
    /// </summary>
    public partial class StartExitTopListWindow : Window
    {
        private readonly MainWindow _mainWindow;

        public StartExitTopListWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            Saves.CheckAddUser();
            CreateTopList();
            _mainWindow = mainWindow;
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Visibility = Visibility.Visible;
            Visibility = Visibility.Hidden;
            _mainWindow.StartNew();
        }

        private void CreateTopList()
        {
            (string Name, int Score)[] result = Saves.Dictionary
                .Select(x => (Name: x.Key, Score: Convert.ToInt32(x.Value["Score"])))
                .OrderBy(x => -x.Score)
                .ToArray();

            for (int i = 0; i < 5; i++)
            {
                string info = ReturnString(result, i);
                switch (i)
                {
                    case 0:
                        Top1_textBlock.Text = info;
                        break;
                    case 1:
                        Top2_textBlock.Text = info;
                        break;
                    case 2:
                        Top3_textBlock.Text = info;
                        break;
                    case 3:
                        Top4_textBlock.Text = info;
                        break;
                    case 4:
                        Top5_textBlock.Text = info;
                        break;
                }
            }
        }

        private static string ReturnString((string Name, int Score)[] data, int index)
        {
            if (data.Length > index)
            {
                return $"{index + 1}. User: {data[index].Name}; Score: {data[index].Score}.";
            }
            return "";
        }

        #region Closing

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Saves.Serialize();
            Application.Current.Shutdown();
        }

        #endregion
    }
}
