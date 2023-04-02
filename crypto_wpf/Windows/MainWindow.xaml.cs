using crypto_wpf.Classes;
using crypto_wpf.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace crypto_wpf.Windows
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            DataTable currencyTable = await viewModel.GetCurrencyTable();
            currency_dataGrid.ItemsSource = currencyTable.DefaultView;

            DataTable topCurrencyTable = await viewModel.GetTopCurrencyTable();
            topCurrency_dataGrid.ItemsSource = topCurrencyTable.DefaultView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            DataStorage.SearchParameter = search_TextBox.Text;
            CoinWindow coinWindow = new CoinWindow();
            coinWindow.Show();
        }

        private void currency_dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataStorage.CoinId = (currency_dataGrid.SelectedItem as DataRowView)?.Row["ID"].ToString(); /* The currently selected row is represented as a DataRow system class and due to this it can use the methods of the DataRow class */
            CoinWindow coinWindow = new CoinWindow();
            coinWindow.Show();
    }

        private void topCurrency_dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataStorage.CoinId = (topCurrency_dataGrid.SelectedItem as DataRowView)?.Row["ID"].ToString(); /* The currently selected row is represented as a DataRow system class and due to this it can use the methods of the DataRow class */
            CoinWindow coinWindow = new CoinWindow();
            coinWindow.Show();
        }
    }
}
