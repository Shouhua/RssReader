using System.Windows;
using RssReader.ViewModel;

namespace RssReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}