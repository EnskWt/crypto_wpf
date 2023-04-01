using crypto_wpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_wpf.ViewModels
{
    public class LoadingViewModel : INotifyPropertyChanged
    {
        private LoadingModel model;

        public LoadingViewModel()
        {
            model = new LoadingModel();
        }

        public async Task<string?> ApiResponse()
        {
            string? response = await model.GetApiStatus();
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            OnPropertyChanged("ApiResponse");
            return response;
        }

        public Boolean MoveToMainWindow() => model.CheckApiStatus();

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
