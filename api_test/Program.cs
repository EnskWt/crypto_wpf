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
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string hashing_algorithm { get; set; }
        public List<string> categories { get; set; }
        public Links links { get; set; }
        public Image image { get; set; }
        public string coingecko_rank { get; set; }
        public string coingecko_score { get; set; }
        public string developer_score { get; set; }
        public string community_score { get; set; }
        public string liquidity_score { get; set; }
        public string public_interest_score { get; set; }
        public Market market_data { get; set; }
        public List<Tickers> tickers { get; set; }
    }

    class LocalMarket
    {
        public string name { get; set; }
    }

    class Tickers
    {
        public LocalMarket market { get; set; }
        public string trust_scrore { get; set; }
        public string trade_url { get; set; }
    }

    class Market
    {
        public Price current_price { get; set; }
        public Price total_volume { get; set; }
        public Price ath { get; set; }
        public Price atl { get; set; }
        public Price high_24h { get; set; }
        public Price low_24h { get; set; }
        public Price price_change_24h_in_currency { get; set; }
        public string price_change_percentage_24h { get; set; }
        public string price_change_percentage_7d { get; set; }
        public string price_change_percentage_30d { get; set; }

    }
    class Price
    {
        public string usd { get; set; }
        public string eur { get; set; }
        public string uah { get; set; }
    }

    class Image
    {
        public string thumb { get; set; }
        public string small { get; set; }
        public string large { get; set; }
    }

    class Links
    {
        public List<string?> homepage { get; set; }
        public List<string?> blockchain_site { get; set; }
        public List<string?> official_forum_url { get; set; }
        public List<string?> chat_url { get; set; }
        public List<string?> announcement_url { get; set; }
        public string subreddit_url { get; set; }
    }
        

    public static async Task Main()
    {
        var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/01coin?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false");
        var result = await response.Content.ReadAsStringAsync();
        var allData = JsonConvert.DeserializeObject<AllData>(result);

        string? go = allData.tickers[0].market.name;
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

