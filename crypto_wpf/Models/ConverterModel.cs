using crypto_wpf.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace crypto_wpf.Models
{
    class ConverterModel
    {
        HttpClient httpClient = new HttpClient();
        public async Task<List<string>> GetCoinsList()
        {
            var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/list");
            var result = await response.Content.ReadAsStringAsync();

            var currencyList = JsonConvert.DeserializeObject<List<Currency>>(result);

            List<string> idsList = new List<string>();
            foreach (Currency? currency in currencyList)
            {
                idsList.Add(currency.id);
                if (idsList.Count >= 30)
                {
                    break;
                }
            }
            return idsList;
        }

        public async Task<double?> GetExchangeRate(string firstCoin, string lastCoin)
        {
            var firstResponse = await httpClient.GetAsync($"https://api.coingecko.com/api/v3/coins/{firstCoin}");
            var firstResult = await firstResponse.Content.ReadAsStringAsync();
            var firstCoinInfo = JsonConvert.DeserializeObject<CoinInfoJsonObject>(firstResult);
            if (firstCoinInfo.market_data != null | firstCoinInfo.market_data.current_price != null)
            {
                if (String.IsNullOrEmpty(firstCoinInfo.market_data.current_price.usd))
                {
                    MessageBox.Show("Error with this coin price.");
                    return null;
                }
            }
            else
            {
                return null;
            }
            var firstPriceString = firstCoinInfo.market_data.current_price.usd;
            var firstPrice = Double.Parse(firstPriceString, CultureInfo.InvariantCulture);


            var lastResponse = await httpClient.GetAsync($"https://api.coingecko.com/api/v3/coins/{lastCoin}");
            var lastResult = await lastResponse.Content.ReadAsStringAsync();
            var lastCoinInfo = JsonConvert.DeserializeObject<CoinInfoJsonObject>(lastResult);
            if (lastCoinInfo.market_data != null | lastCoinInfo.market_data.current_price != null)
            {
                if (String.IsNullOrEmpty(lastCoinInfo.market_data.current_price.usd))
                {
                    MessageBox.Show("Error with this coin price.");
                    return null;
                }
            }
            else
            {
                return null;
            }
            var lastPriceString = lastCoinInfo.market_data.current_price.usd;
            var lastPrice = Double.Parse(lastPriceString, CultureInfo.InvariantCulture);

            double exchangeRate = firstPrice / lastPrice;

            return exchangeRate;
        }

        public async Task<double?> ConvertCurrencies(int firstSum, string firstCoin, string lastCoin)
        {
            double? exchangeRate = await GetExchangeRate(firstCoin, lastCoin);
            if (exchangeRate == null)
            {
                return null;
            }
            double? lastSum = firstSum * exchangeRate;
            return lastSum;
        }
    }
}
