using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRPO_pr9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void CreateDirectory()
        {
            if (!Directory.Exists("..\\net8.0-windows\\Doctor"))
                Directory.CreateDirectory("..\\net8.0-windows\\Doctor");
            if (!Directory.Exists("..\\net8.0 - windows\\Patient"))
                Directory.CreateDirectory("..\\net8.0-windows\\Patient");
        }

        public MainWindow()
        {
            CreateDirectory();
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle();
        }
    }
}