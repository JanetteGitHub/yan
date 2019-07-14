

namespace yan.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using yan.Common.Models;
    using yan.Services;

    class ServicesViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<ServiciosyNegocios> services;

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

        private async void LoadServicios()
        {
            var response = await this.apiService.GetList<ServiciosyNegocios>("https://yanapi20190713080118.azurewebsites.net", "/api", "/ServiciosyNegocios");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list=(List <ServiciosyNegocios>) response.Result;
            this.Services = new ObservableCollection<ServiciosyNegocios>(list);

        }
    }
}
