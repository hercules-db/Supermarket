namespace Supermarket.Program
{
    using System.Windows;

    using Data.Context;
    using Data.Sync;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConfirmExit = "Do you want to close this window?";
        private const string SyncSuccess = "Syncing successful!";
        private const string SyncError = "Syncing failed! Please try again.";

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            var import = new Import();
            Application.Current.MainWindow = import;
            this.Close();
            import.Show();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var export = new Export();
            Application.Current.MainWindow = export;
            this.Close();
            export.Show();
        }

        private void SyncSql_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sql.Sync(new SupermarketSqlContext());
                MessageBox.Show(SyncSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch
            {
                MessageBox.Show(SyncError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void SyncMySql_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mySqlSync = MySql.Sync(new SupermarketSqlContext(), new SupermarketMySqlContext());
                MessageBox.Show(mySqlSync, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch
            {
                MessageBox.Show(SyncError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(ConfirmExit, MessageStatus.Confirmation.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}