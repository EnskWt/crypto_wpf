using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace crypto_wpf.Classes
{
    // Currency class for list of currencies
    class Currency
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
    }

    // Coins class for Top7 list of currencies
    class TopCoinsJsonObject
    {
        public List<Coins> coins { get; set; }

    }
    class Coins
    {
        public Item item { get; set; }
    }
    class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }

    //Class for searching coins
    class SearchedInfoJsonObject
    {
        public List<Coin> coins { get; set; }
    }
    class Coin
    {
        public string id { get; set; }
    }

    // Class for detailed info about coin
    class CoinInfoJsonObject
    {
        public string? id { get; set; }
        public string? symbol { get; set; }
        public string? name { get; set; }
        public string? hashing_algorithm { get; set; }
        public Links? links { get; set; }
        public Image? image { get; set; }
        public string? coingecko_rank { get; set; }
        public string? coingecko_score { get; set; }
        public string? developer_score { get; set; }
        public string? community_score { get; set; }
        public string? liquidity_score { get; set; }
        public string? public_interest_score { get; set; }
        public Market? market_data { get; set; }
        public List<Ticker>? tickers { get; set; }
    }

    class LocalMarket
    {
        public string? name { get; set; }
    }

    class Ticker
    {
        public LocalMarket? market { get; set; }
        public string? trust_score { get; set; }
        public string? trade_url { get; set; }
    }

    class Market
    {
        public Price? current_price { get; set; }
        public Price? total_volume { get; set; }
        public Price? ath { get; set; }
        public Price? atl { get; set; }
        public Price? high_24h { get; set; }
        public Price? low_24h { get; set; }
        public Price? price_change_24h_in_currency { get; set; }
        public string? price_change_percentage_24h { get; set; }
        public string? price_change_percentage_7d { get; set; }
        public string? price_change_percentage_30d { get; set; }

    }
    class Price
    {
        public string? usd { get; set; }
        public string? eur { get; set; }
        public string? uah { get; set; }
    }

    class Image
    {
        public ImageSource? thumb { get; set; }
        public ImageSource? small { get; set; }
        public ImageSource? large { get; set; }
    }

    class Links
    {
        public List<string?> homepage { get; set; }
        public List<string?> blockchain_site { get; set; }
        public List<string?> chat_url { get; set; }
        public string? subreddit_url { get; set; }
    }
}
