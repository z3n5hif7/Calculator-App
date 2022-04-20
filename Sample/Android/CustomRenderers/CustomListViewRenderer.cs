﻿using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Sample;
using Sample.Droid;
using Android.Content;

[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewRenderer))]
namespace Sample.Droid
{
    class CustomListViewRenderer : ListViewRenderer
    {
        public CustomListViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            //Remove the orange highlight
            Control.SetSelector(Android.Resource.Color.Transparent);
            Control.CacheColorHint = Color.Transparent.ToAndroid();
        }
    }
}