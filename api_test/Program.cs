using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Json;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static HttpClient httpClient = new HttpClient();

    class AllData
    {
        public List<Coins> coins { get; set; }
        
    }
    class Coins
    {
        public Items item { get; set; }
    }
    class Items
    {
        public string id { get; set; }
        public string coin_id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string market_cap_rank { get; set; }
        public string thumb { get; set; }
        public string small { get; set; }
        public string large { get; set; }
        public string slug { get; set; }
        public string price_btc { get; set; }
        public string score { get; set; }
    }

  

    public static async Task Main()
    {
        var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/search/trending");
        var result = await response.Content.ReadAsStringAsync();
        var wynik = JsonConvert.DeserializeObject<AllData>(result);

        string? go = wynik.coins[0].item.id.ToString();
        await Console.Out.WriteLineAsync(go);

        //Currency? currency = JsonSerializer.Deserialize<Currency[]>(result)[0];

        //await Console.Out.WriteLineAsync($"id: {currency.id}, symbol: {currency.symbol}, name: {currency.name}");
        //
    }
}

//static async Task Main()
//{
//    using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.coingecko.com/api/v3/coins/list");
//    using HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
//    Currency result = (await response.Content.ReadFromJsonAsync<Currency[]>())[0];
//    Console.ReadKey();
//    await Console.Out.WriteLineAsync(result.id);
//}

