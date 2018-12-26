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
using Android.Support.V7.App;

namespace Firebase_Notification_App
{
    [Activity(Label = "GeneralPopupActivity", Theme = "@style/AppTheme.Transparent")]
    public class GeneralPopupActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            Window.AddFlags(WindowManagerFlags.ShowWhenLocked 
                | WindowManagerFlags.DismissKeyguard
                | WindowManagerFlags.KeepScreenOn 
                | WindowManagerFlags.TurnScreenOn 
                | WindowManagerFlags.AllowLockWhileScreenOn);

            // Create your application here

            //Title = "";
            string title = Intent.GetStringExtra("Title") ?? string.Empty;
            string description = Intent.GetStringExtra("Description") ?? string.Empty;

            SetDialog(title, description);
        }

        public void SetDialog(string title, string description)
        {
            Android.Support.V7.App.AlertDialog.Builder alertDialog = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertDialog.SetTitle(title);
            alertDialog.SetMessage(description);
            alertDialog.SetCancelable(false);
            alertDialog.SetPositiveButton("Delete", (senderAlert, args) => {
                Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
            });

            alertDialog.SetNegativeButton("Cancel", (senderAlert, args) => {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });
            Dialog dialog = alertDialog.Create();
            dialog.Show();

            
        }
    }
}