using crypto_wpf.Classes;
using crypto_wpf.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        DataTable table = new DataTable();

        private readonly MainViewModel viewModel = new MainViewModel();
        public class Currency
        {
            public string? id { get; set; }
            public string? symbol { get; set; }
            public string? name { get; set; }
        }


        private async void Window_Initialized(object sender, EventArgs e)
        {
            DataTable currencyTable = await viewModel.GetCurrencyTable();
            currency_dataGrid.ItemsSource = currencyTable.DefaultView;

            DataTable topCurrencyTable = await viewModel.GetTopCurrencyTable();
            topCurrency_dataGrid.ItemsSource = topCurrencyTable.DefaultView;
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
