using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace Sample.Droid
{
    [Activity(Label = "Sample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            var density = Resources.DisplayMetrics.Density;
            App.ScreenWidth = Resources.DisplayMetrics.WidthPixels / density;
            App.ScreenHeight = Resources.DisplayMetrics.HeightPixels / density;
            App.androidHeightPixels = Android.Content.Res.Resources.System.DisplayMetrics.HeightPixels;
            App.DeviceType = 1;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                App.ScreenHeight = (16 * App.ScreenWidth) / 9;
                App.adjustedHeight = App.ScreenHeight;
                App.isPhone = true;
            }

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                App.ScreenWidth = (9 * App.ScreenHeight) / 16;
                App.adjustedWidth = App.ScreenWidth;
                App.isPhone = false;
            }


            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}