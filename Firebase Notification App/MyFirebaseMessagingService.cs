using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace Firebase_Notification_App
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            openPopupActivity(message);
        }

        private void openPopupActivity(RemoteMessage message)
        {
            Intent intent = new Intent(this, typeof(GeneralPopupActivity));
            intent.PutExtra("Title", message.GetNotification().Title);
            intent.PutExtra("Description", message.GetNotification().Body);
            StartActivity(intent);
        }
    }

}