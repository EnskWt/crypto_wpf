using crypto_wpf.Classes;
using crypto_wpf.Models;
using crypto_wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.WebRequestMethods;

namespace crypto_wpf.Windows
{
    public partial class CoinWindow : Window
    {
        private readonly CoinViewModel viewModel = new CoinViewModel();
        public CoinWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await FillWindow();

            viewModel.Theme();
        }
        public async Task FillWindow()
        {
            var converter = new ImageSourceConverter();
            if (DataStorage.CoinId == null)
            {
                await viewModel.GetCoinId();
            }
            var coinInfoObject = await viewModel.GetCoinInfoObject();
            if (coinInfoObject != null)
            {
                coin_Picture.Source = converter.ConvertFromString($"{coinInfoObject.image.large}") as ImageSource;

                coinName.Content = coinInfoObject.id;
                coinSymbol.Content = coinInfoObject.symbol;
                coinId.Content = coinInfoObject.id;
                coinHashing.Content = coinInfoObject.hashing_algorithm;

                if (coinInfoObject.tickers.Count > 0)
                {
                    marketName.Content = coinInfoObject.tickers[0].market.name;
                    trustScore.Content = coinInfoObject.tickers[0].trust_score;
                }
                else
                {
                    marketName.Content = "No data";
                    trustScore.Content = "No data";
                }

                cgRank.Content = coinInfoObject.coingecko_rank;
                cgScore.Content = coinInfoObject.coingecko_score;
                developerScore.Content = coinInfoObject.coingecko_score;
                communityScore.Content = coinInfoObject.coingecko_score;
                liquidityScore.Content = coinInfoObject.coingecko_score;
                interestScore.Content = coinInfoObject.coingecko_score;

                change24h.Content = coinInfoObject.market_data.price_change_percentage_24h;
                change7d.Content = coinInfoObject.market_data.price_change_percentage_7d;
                change30d.Content = coinInfoObject.market_data.price_change_percentage_30d;

                if (coinInfoObject.tickers.Count > 0)
                {
                    marketUrl_Hyperlink.NavigateUri = new Uri(coinInfoObject.tickers[0].trade_url);
                }
                else
                {
                    marketUrl_Hyperlink_Text.Text = string.Empty;
                    marketUrl_Text.Text = "No market's URL";
                }


                if (!String.IsNullOrEmpty(coinInfoObject.links.homepage[0]))
                {
                    homepage_Hyperlink.NavigateUri = new Uri(coinInfoObject.links.homepage[0]);
                }
                else
                {
                    homepage_Hyperlink_Text.Text = string.Empty;
                    homepage_Text.Text = "No homepage";
                }

                if (!String.IsNullOrEmpty(coinInfoObject.links.blockchain_site[0]))
                {
                    blockchain_Hyperlink.NavigateUri = new Uri(coinInfoObject.links.blockchain_site[0]);
                }
                else
                {
                    blockchain_Hyperlink_Text.Text = string.Empty;
                    blockchain_Text.Text = "No blockchain";
                }

                if (!String.IsNullOrEmpty(coinInfoObject.links.chat_url[0]))
                {
                    chat_Hyperlink.NavigateUri = new Uri(coinInfoObject.links.chat_url[0]);
                }
                else
                {
                    chat_Hyperlink_Text.Text = string.Empty;
                    chat_Text.Text = "No chat";
                }

                if (!String.IsNullOrEmpty(coinInfoObject.links.subreddit_url))
                {
                    reddit_Hyperlink.NavigateUri = new Uri(coinInfoObject.links.subreddit_url);
                }
                else
                {
                    reddit_Hyperlink_Text.Text = string.Empty;
                    reddit_Text.Text = "No reddit";
                }

                currency_comboBox.SelectedIndex = 0;
                coinPrice.Content = coinInfoObject.market_data.current_price.usd;
                coinVolume.Content = coinInfoObject.market_data.total_volume.usd;

                coinAth.Content = coinInfoObject.market_data.ath.usd;
                coinAtl.Content = coinInfoObject.market_data.atl.usd;

                high24h.Content = coinInfoObject.market_data.high_24h.usd;
                low24h.Content = coinInfoObject.market_data.high_24h.usd;
            }
            else
            {
                MessageBox.Show("Some troubles with this coin, try other");
            }
        }

        private void hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void eur_item_Selected(object sender, RoutedEventArgs e)
        {
            var coinInfoObject = DataStorage.LocalCoinInfoObject;
            if (coinInfoObject != null)
            {
                coinPrice.Content = coinInfoObject.market_data.current_price.eur;
                coinVolume.Content = coinInfoObject.market_data.total_volume.eur;

                coinAth.Content = coinInfoObject.market_data.ath.eur;
                coinAtl.Content = coinInfoObject.market_data.atl.eur;

                high24h.Content = coinInfoObject.market_data.high_24h.eur;
                low24h.Content = coinInfoObject.market_data.high_24h.eur;
            }
        }

        private void usd_item_Selected(object sender, RoutedEventArgs e)
        {
            var coinInfoObject = DataStorage.LocalCoinInfoObject;
            coinPrice.Content = coinInfoObject.market_data.current_price.usd;
            coinVolume.Content = coinInfoObject.market_data.total_volume.usd;

            coinAth.Content = coinInfoObject.market_data.ath.usd;
            coinAtl.Content = coinInfoObject.market_data.atl.usd;

            high24h.Content = coinInfoObject.market_data.high_24h.usd;
            low24h.Content = coinInfoObject.market_data.high_24h.usd;
        }

        private void uah_item_Selected(object sender, RoutedEventArgs e)
        {
            var coinInfoObject = DataStorage.LocalCoinInfoObject;
            if (coinInfoObject != null)
            {
                coinPrice.Content = coinInfoObject.market_data.current_price.uah;
                coinVolume.Content = coinInfoObject.market_data.total_volume.uah;

                coinAth.Content = coinInfoObject.market_data.ath.uah;
                coinAtl.Content = coinInfoObject.market_data.atl.uah;

                high24h.Content = coinInfoObject.market_data.high_24h.uah;
                low24h.Content = coinInfoObject.market_data.high_24h.uah;
            }
        }

        private async void search_Button_Click(object sender, RoutedEventArgs e)
        {
            DataStorage.SearchParameter = search_TextBox.Text;
            await FillWindow();
        }
    }
}
