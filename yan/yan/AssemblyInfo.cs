using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace yan
{
    
    using yan.Infrastructure.Views;

    public partial class App:Application
    {
        public App()
        {

            InitializeComponent();
            MainPage = new ServicesPage();
        }
        protected override void OnStart()
        {
            //Handle when your app starts
        }
    }
}
