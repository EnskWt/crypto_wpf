using crypto_wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_wpf.ViewModels
{
    internal class ConverterViewModel : ViewModel
    {
        private ConverterModel model;
        public ConverterViewModel()
        {
            model = new ConverterModel();
        }

        public async Task<double?> Converter(int firstNum, string firstCoin, string lastCoin)
        {
            double? result = await model.ConvertCurrencies(firstNum, firstCoin, lastCoin);
            return result;
        }

        public async ValueTask<List<string>> GetCoinsList()
        {
            List<string> result = await model.GetCoinsList();
            return result;
        }
    }
}
