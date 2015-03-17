using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Supermarket.Data;
using Supermarket.Data.Migrations;

namespace Supermarket.Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ExitConfirm = "Do you want to close this window?";
        private const string SyncSuccess = "Syncing successful!";
        private const string SyncError = "Syncing failed! Please try again.";

        public MainWindow()
        {
            InitializeComponent();
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

        private void Sync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration.Sync(new SupermarketSqlContext());
            }
            catch
            {
                MessageBox.Show(SyncError, MessageStatus.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            MessageBox.Show(SyncSuccess, MessageStatus.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(ExitConfirm, MessageStatus.Confirmation.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}