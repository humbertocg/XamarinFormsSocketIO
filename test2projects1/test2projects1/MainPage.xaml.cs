using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test2projects1;
using Xamarin.Forms;

namespace test2projects1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            /*MessagingCenter.Subscribe<object, string>(this, "Hi", (sender, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    String a = arg;
                });
            });*/
            /*MessagingCenter.Subscribe<string, string>(this, "Hi", (sender, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    String a = arg;
                    DisplayAlert("Message Received", arg, "OK");
                });
            });*/
            DependencyService.Get<ISocket>().OpenConnection("http://192.168.1.75:8281");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           MessagingCenter.Subscribe<string,string>(this, "Hi", (sender,arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //String a = arg;
                    DisplayAlert("Message Received", arg, "Entendido");
                });
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Hi");
        }
    }
}
