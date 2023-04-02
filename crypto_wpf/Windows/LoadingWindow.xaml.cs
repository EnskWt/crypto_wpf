using crypto_wpf.ViewModels;
using crypto_wpf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace crypto_wpf
{
    public partial class LoadingWindow : Window
    {
        private readonly LoadingViewModel viewModel = new LoadingViewModel();
        public LoadingWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.ApiStatus())
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await viewModel.ApiResponse();
        }
    }
}
