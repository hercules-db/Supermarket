namespace Supermarket.Program
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        public Export()
        {
            this.InitializeComponent();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}