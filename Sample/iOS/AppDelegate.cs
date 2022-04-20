using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using UIKit;

namespace Sample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            App.ScreenWidth = (float)UIScreen.MainScreen.Bounds.Width;
            App.ScreenHeight = (float)UIScreen.MainScreen.Bounds.Height;
            App.originalHeight = App.ScreenHeight;
            App.originalWidth = App.ScreenWidth;
            App.appScale = (float)UIScreen.MainScreen.Scale;
            App.DeviceType = 0;

            //Check if we are running on a phone
            App.isPhone = GetIsRunningOnPhone();

            if (App.isPhone)
            {
                App.ScreenHeight = (16 * App.ScreenWidth) / 9;
                App.adjustedHeight = App.ScreenHeight;
                Debug.WriteLine("TYPE: PHONE");
            }
            else
            {
                App.ScreenWidth = (9 * App.ScreenHeight) / 16;
                App.adjustedWidth = App.ScreenWidth;
                Debug.WriteLine("TYPE: TABLET");
            }


            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        bool GetIsRunningOnPhone()
        {
            switch (UIKit.UIDevice.CurrentDevice.UserInterfaceIdiom)
            {
                case UIUserInterfaceIdiom.Pad:
                    return false;
                default:
                    return true;
            }
        }
    }
}
