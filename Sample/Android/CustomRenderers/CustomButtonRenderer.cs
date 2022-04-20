using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Sample;
using Sample.Droid;
using Android.Content;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Sample.Droid
{
    class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            CustomButton elem = Element as CustomButton;
            Control.SetAllCaps(elem.AutoCapitalization);
        }
    }
}