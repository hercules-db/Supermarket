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
        private const string FileTypeZip = ".zip";
        private const string FileFilterZip = "Archives (.zip)|*.zip";

        private const string FileTypeXml = ".xml";
        private const string FileFilterXml = "Archives (.xml)|*.xml";

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
            var importMenu = (ImportMenu.SelectedValue as ComboBoxItem).Content.ToString();

            switch (importMenu)
            {
                case "Excel":
                    dialog.DefaultExt = FileTypeZip;
                    dialog.Filter = FileFilterZip;
                    break;
                case "XML":
                    dialog.DefaultExt = FileTypeXml;
                    dialog.Filter = FileFilterXml;
                    break;
                case "Mongo": break; // TODO
            }

            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                FileNameTextBox.Text = fileName;

                var confirm = MessageBox.Show(ConfirmImport, MessageStatus.Confirmation.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (confirm == MessageBoxResult.Yes)
                {
                    var context = new SupermarketSqlContext();
                    Xml.Import(fileName, context);

                    try
                    {
                        switch (importMenu)
                        {
                            case "Excel":
                                ImportedDates.Text = string.Join("\r\n", Excel.Import(fileName, context)) + "\r\nDone!";
                                break;
                            case "XML":
                                //Xml.Import(fileName, context); // TODO
                                break;
                            case "Mongo":
                                Mongo.Import(context); // TODO
                                break;
                        }

                        MessageBox.Show(ImportSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    catch
                    {
                        MessageBox.Show(ImportError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
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