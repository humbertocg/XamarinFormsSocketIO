using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;

namespace test2projects1.Droid.Notificacion
{
    public class Notificacion //: global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static readonly int ButtonClickNotificationId = 1000;
        public Notificacion(String Mensaje)
        {
            madeANotification(Mensaje);
        }
        public void madeANotification(String Mensaje)
        {
            int count = 0;
            Context context = Android.App.Application.Context;
            // Pass the current button press count value to the next activity:
            Bundle valuesForActivity = new Bundle();
            valuesForActivity.PutString("Mensaje", Mensaje);
            
            // When the user clicks the notification, SecondActivity will start up.
            Intent resultIntent = new Intent(context, typeof(MainActivity));

            // Pass some values to SecondActivity:
            resultIntent.PutExtras(valuesForActivity);
            /*
            // Construct a back stack for cross-task navigation:
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(Android.App.Application.Context);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(AnotherPage)));
            stackBuilder.AddNextIntent(resultIntent);
            */
            // Create the PendingIntent with the back stack:            
            PendingIntent resultPendingIntent =
                PendingIntent.GetActivity(context, 0, resultIntent, PendingIntentFlags.OneShot);  //.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
            
            // Build the notification:
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
                .SetAutoCancel(true)                    // Dismiss from the notif. area when clicked
                .SetContentIntent(resultPendingIntent)  // Start 2nd activity when the intent is clicked.
                .SetContentTitle("Notificación Socket.IO")      // Set its title
                .SetNumber(count)                       // Display the count in the Content Info
                .SetSmallIcon(Resource.Drawable.icon)  // Display this icon
                .SetContentText(Mensaje); // The message to display.

            // Finally, publish the notification:
            NotificationManager notificationManager =
                (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(ButtonClickNotificationId, builder.Build());

            // Increment the button press count:
            count++;
        }
    }
}