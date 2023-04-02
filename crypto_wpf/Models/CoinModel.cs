using crypto_wpf.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace crypto_wpf.Models
{
    class CoinModel
    {
        HttpClient httpClient = new HttpClient();       
        public async Task<CoinInfoJsonObject> GetCoinInfo()
        {
            string? id = DataStorage.CoinId;
            if (id != null)
            {
                var response = await httpClient.GetAsync($"https://api.coingecko.com/api/v3/coins/{id}");
                var result = await response.Content.ReadAsStringAsync();
                var coinInfo = JsonConvert.DeserializeObject<CoinInfoJsonObject>(result);
                DataStorage.LocalCoinInfoObject = coinInfo;
                DataStorage.CoinId = null;
                return coinInfo;
            }
            return null;
        }

        public async Task GetCoinId()
        {
            string? parameter = DataStorage.SearchParameter;
            var response = await httpClient.GetAsync($"https://api.coingecko.com/api/v3/search?query={parameter}");
            var result = await response.Content.ReadAsStringAsync();
            var coinInfo = JsonConvert.DeserializeObject<SearchedInfoJsonObject>(result);
            if (coinInfo.coins.Count > 0)
            {
                var id = coinInfo.coins[0].id;
                DataStorage.CoinId = id;
                DataStorage.SearchParameter = string.Empty;
            }
            return;
        }
    }
}
