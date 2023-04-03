using crypto_wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class ConverterWindow : Window
    {
        private readonly ConverterViewModel viewModel = new ConverterViewModel();
        public ConverterWindow()
        {
            InitializeComponent();
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            viewModel.Theme();

            List<string> idsList = await viewModel.GetCoinsList();

            firstCoinsList_comboBox.ItemsSource = idsList;
            lastCoinsList_comboBox.ItemsSource = idsList;
        }

        private async Task FillFields()
        {
            if (firstCoinsList_comboBox.SelectedItem == null | lastCoinsList_comboBox.SelectedItem == null | String.IsNullOrEmpty(firstSum_Field.Text))
            {
                return;
            }

            if(!Regex.IsMatch(firstSum_Field.Text, "^[0-9]"))
            {
                return;
            }

            double? result = await viewModel.Converter(Int32.Parse(firstSum_Field.Text), firstCoinsList_comboBox.SelectedItem.ToString(), lastCoinsList_comboBox.SelectedItem.ToString());
            if (result == null)
            {
                lastSum_Field.Text = "Error";
                return;
            }
            lastSum_Field.Text = result.ToString();
        }

        private async void firstCoinsList_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await FillFields();
        }

        private async void lastCoinsList_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await FillFields();
        }

        private async void firstSum_Field_TextChanged(object sender, TextChangedEventArgs e)
        {
            await FillFields();
        }
    }
}
