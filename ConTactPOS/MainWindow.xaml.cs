using ConTactPOS.ViewModels;
using ConTactPOS.Views;
using System.Windows;

namespace ConTactPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
            //Content = new ShowUC();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int c = (int )onoff.Width.Value;
            if (c == 200) {
                onoff.Width = new GridLength(50);
            }
            
            if (c == 50)
            {
                onoff.Width = new GridLength(200);
            }
        }
    }
}