namespace Supermarket.Program
{
    using System.Windows;

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
        private const string InsertError = "Inserting Failed!";
        private const string InsertSuccess = "Inserting Successful";

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
                    try
                    {
                        var excel = new Excel();
                        ImportDates.Text = string.Join("\r\n", excel.Import(fileName, new SupermarketSqlContext())) + "\r\nDone!";
                    }
                    catch
                    {
                        MessageBox.Show(InsertError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                    MessageBox.Show(InsertSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}