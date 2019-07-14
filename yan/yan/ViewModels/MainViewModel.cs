namespace yan.ViewModels
{
    class MainViewModel
    {
        public ServicesViewModel Services { get; set; }

        public MainViewModel()
        {
            this.Services = new ServicesViewModel();

        }
    }
}
