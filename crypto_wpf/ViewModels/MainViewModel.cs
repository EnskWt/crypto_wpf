using crypto_wpf.Classes;
using crypto_wpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace crypto_wpf.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private MainModel model;

        public MainViewModel()
        {
            model = new MainModel();
        }
        public async Task<DataTable> GetCurrencyTable()
        {
            DataTable currencyTable = await model.FillCurrencyTable();
            return currencyTable;
        }

        public async Task<DataTable> GetTopCurrencyTable()
        {
            DataTable topCurrencyTable = await model.FillTopCurrencyTable();
            return topCurrencyTable;
        }


        public event PropertyChangedEventHandler PropertyChanged;
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
