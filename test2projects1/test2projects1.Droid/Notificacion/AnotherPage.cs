using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace test2projects1.Droid.Notificacion
{
    public class AnotherPage : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public AnotherPage()
        {
            /*int count = Intent.Extras.GetInt("count", -1);

            // No count was passed? Then just return.
            if (count <= 0)
                return;*/
            String Mensaje = Intent.Extras.GetString("Mensaje", "");
            MessagingCenter.Send("texto", "Hi", "Mensaje " + Mensaje);
        }
        protected override void OnCreate(Bundle bundle)
        {
            String Mensaje = Intent.Extras.GetString("Mensaje", "");
            MessagingCenter.Send("texto", "Hi", "Mensaje " + Mensaje);
        }
    }
}