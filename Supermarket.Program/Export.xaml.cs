namespace Supermarket.Program
{
    using System.Windows;
    using System.Windows.Controls;
    using Supermarket.Data.Context;
    using Supermarket.Data.Exports;

    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        private const string ExportError = "Exporting Failed!";
        private const string ExportSuccess = "Exporting Successful!";

        public Export()
        {
            this.InitializeComponent();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var exportMenu = (ExportMenu.SelectedValue as ComboBoxItem).Content.ToString();
            var context = new SupermarketSqlContext();

            switch (exportMenu)
            {
                case "Excel": break;
                case "PDF": break;
                case "XML": break;
                case "JSON":
                    JsonExport(context);
                    break;
                case "MySQL": break;
            }
        }

        private void JsonExport(ISupermarketContext context)
        {
            try
            {
                Json.Export(context);
                MessageBox.Show(ExportSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch
            {
                MessageBox.Show(ExportError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}