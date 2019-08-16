using System.Windows;

namespace WpfAppEntity
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

        private void UcLogin_success(object sender, System.EventArgs e)
        {
            MessageBox.Show(sender.ToString());
            ucLoginForm.Visibility = Visibility.Hidden;
            ucGridView.Visibility = Visibility.Visible;
        }

        private void UcLogin_fail(object sender, System.EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void UGridView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
