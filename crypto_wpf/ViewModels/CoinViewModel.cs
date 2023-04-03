using crypto_wpf.Classes;
using crypto_wpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace crypto_wpf.ViewModels
{
    internal class CoinViewModel : ViewModel
    {
        private CoinModel model;
        public CoinViewModel()
        {
            model = new CoinModel();
        }

        public async Task<CoinInfoJsonObject> GetCoinInfoObject()
        {
            var coinInfo = await model.GetCoinInfo();
            return coinInfo;
        }

        public Task GetCoinId()
        {
            return model.GetCoinId();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }
        }
    }
}
