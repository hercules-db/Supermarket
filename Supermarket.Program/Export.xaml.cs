namespace Supermarket.Program
{
    using System;
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

            try
            {
                switch (exportMenu)
                {
                    case "Excel": Excel.Export(context); break; // TODO
                    case "PDF": Pdf.Export(context, StartDate.SelectedDate, EndDate.SelectedDate); break; // TODO
                    case "XML": Xml.Export(context, StartDate.SelectedDate, EndDate.SelectedDate); break;
                    case "JSON": Json.Export(context, StartDate.SelectedDate, EndDate.SelectedDate); break;
                    case "MySQL": break; // TODO
                }

                MessageBox.Show(ExportSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception)
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