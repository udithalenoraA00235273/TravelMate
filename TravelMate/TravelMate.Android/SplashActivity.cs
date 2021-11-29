using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelMate.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG,"");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupwork = new Task(() => { SimulateStartup(); });
            startupwork.Start();
        }

        async void SimulateStartup()
        {
            Log.Debug(TAG,"");
            await Task.Delay(1000);
            Log.Debug(TAG,"");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}