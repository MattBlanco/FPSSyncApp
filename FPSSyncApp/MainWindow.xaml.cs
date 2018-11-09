using System.Windows;
using FPSSyncApp.Utilities;

namespace FPSSyncApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = ActiveSteamUser.getId();
        }
    }
}
