using crypto_wpf.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace crypto_wpf.Models
{
    class MainModel
    {
        HttpClient httpClient = new HttpClient();

        public async Task<DataTable> FillCurrencyTable()
        {
            var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/list");
            var result = await response.Content.ReadAsStringAsync();

            var currencyList = JsonConvert.DeserializeObject<List<Currency>>(result);

            var table = new DataTable();

            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Symbol", typeof(string));

            foreach (Currency? currency in currencyList)
            {
                DataRow row = table.NewRow();
                row["ID"] = currency.id;
                row["Name"] = currency.name;
                row["Symbol"] = currency.symbol;

                table.Rows.Add(row);
            }
            return table;   
        }

        public async Task<DataTable> FillTopCurrencyTable()
        {
            var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/search/trending");
            var result = await response.Content.ReadAsStringAsync();
            var topCurrencyList = JsonConvert.DeserializeObject<TopCoinsJsonObject>(result);

            var table = new DataTable();

            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Symbol", typeof(string));

            for (int i = 0; i < 7; i++)
            {
                DataRow row = table.NewRow();
                row["ID"] = topCurrencyList.coins[i].item.id;
                row["Name"] = topCurrencyList.coins[i].item.name;
                row["Symbol"] = topCurrencyList.coins[i].item.symbol;

                table.Rows.Add(row);
            }
            return table;
        }
    }
}
