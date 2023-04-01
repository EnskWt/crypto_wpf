using crypto_wpf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace crypto_wpf.Models
{
    class LoadingModel
    {
        HttpClient httpClient = new HttpClient();
        record Message(string gecko_says);
        string verifyMessage = string.Empty;

        public Boolean CheckApiStatus()
        {
            if (verifyMessage == "(V3) To the Moon!")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error with API's server.");
                return false;
            }
        }

        public async Task<string?> GetApiStatus()
        {
            object? data = await httpClient.GetFromJsonAsync("https://api.coingecko.com/api/v3/ping", typeof(Message));
            if (data is Message message)
            {
                verifyMessage = message.gecko_says;
                return verifyMessage;
            }
            else
            {
                return null;
            }
        }
    }
}
