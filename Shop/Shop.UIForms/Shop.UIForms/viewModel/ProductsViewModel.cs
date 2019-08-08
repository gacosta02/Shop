using Common.Models;
using Common.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Shop.UIForms.viewModel
{
   public class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Product> products;
        private bool isRefreshing;
        public ObservableCollection<Product> Products
        {
            get => this.products;
            set => this.SetValue(ref this.products, value);
        }
        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }
        public ProductsViewModel()
        {
            this.LoadProducts();
            this.apiService = new ApiService();
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;   
            var response = await this.apiService.GetListAsync<Product>(
                "https://localhost:44379",
                "/api",
                "/Products");
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                   response.Message,
                    "Accept");
                return;
            }
            var myProducts = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(myProducts);
        }
    }
}
