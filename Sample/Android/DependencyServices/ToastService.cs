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
using Sample.Droid;
using Sample;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastService))]
namespace Sample.Droid
{
    class ToastService : iToastService
    {
        public void Show(string message, bool isLong)
        {
            Toast.MakeText(Android.App.Application.Context, message, isLong ? ToastLength.Long : ToastLength.Short).Show();
        }
    }
}