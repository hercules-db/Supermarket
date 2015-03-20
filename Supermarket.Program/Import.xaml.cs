namespace Supermarket.Program
{
    using System.Windows;
    using System.Windows.Controls;

    using Microsoft.Win32;

    using Data.Context;
    using Data.Imports;

    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        private const string FileType = ".zip";
        private const string FileFilter = "Archives (.zip)|*.zip";
        private const string ConfirmImport = "Begin import?";
        private const string ImportError = "Importing Failed!";
        private const string ImportSuccess = "Importing Successful!";

        public Import()
        {
            this.InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.DefaultExt = FileType;
            dialog.Filter = FileFilter;

            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                FileNameTextBox.Text = fileName;

                var result = MessageBox.Show(ConfirmImport, MessageStatus.Confirmation.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var importMenu = (ImportMenu.SelectedValue as ComboBoxItem).Content.ToString();

                    switch (importMenu)
                    {
                        case "Excel":
                            ImportedDates.Text = ExcelImport(fileName);
                            break;
                        case "PDF": break;
                        case "XML": break;
                        case "JSON": break;
                        case "MySQL": break;
                    }
                }
            }
        }

        private string ExcelImport(string fileName)
        {
            var importDates = ImportError;

            try
            {
                Excel.Import(fileName, new SupermarketOracleContext());
                importDates = string.Join("\r\n", Excel.Import(fileName, new SupermarketSqlContext())) + "\r\nDone!";
                MessageBox.Show(ImportSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch
            {
                MessageBox.Show(ImportError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return importDates;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

    }
}