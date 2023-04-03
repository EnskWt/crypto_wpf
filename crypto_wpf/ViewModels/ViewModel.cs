using crypto_wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace crypto_wpf.ViewModels
{
    internal class ViewModel
    {
        public void Theme()
        {
            string style = DataStorage.CurrentStyle;
            var uri = new Uri("Windows/Styles/" + style + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
