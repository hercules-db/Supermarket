using System;

namespace Supermarket.Program
{
    using System.Windows;
    using System.Windows.Controls;

    using Data.Context;
    using Data.Exports;

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
            StartDate.SelectedDate = DateTime.Now;
            EndDate.SelectedDate = DateTime.Now;
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
                    JsonExport(context, StartDate.SelectedDate, EndDate.SelectedDate);
                    break;
                case "MySQL": break;
            }
        }

        private void JsonExport(ISupermarketContext context, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                Json.Export(context, startDate, endDate);
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