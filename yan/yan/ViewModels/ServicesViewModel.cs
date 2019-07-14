

namespace yan.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using yan.Common.Models;
    using yan.Services;

    class ServicesViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<ServiciosyNegocios> services;

        private bool isRefreshing;

        public ObservableCollection<ServiciosyNegocios> Services 
        {
            get { return this.services; }
            set { this.SetValue(ref this.services, value); }
        }
        public ServicesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadServicios();
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        private async void LoadServicios()
        {
            this.isRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetList<ServiciosyNegocios>(url, "/api", "/ServiciosyNegocios");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list=(List <ServiciosyNegocios>) response.Result;
            this.Services = new ObservableCollection<ServiciosyNegocios>(list);
            this.IsRefreshing = false;
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadServicios);
            }
        }
    }
}
