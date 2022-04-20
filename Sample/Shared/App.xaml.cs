using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sample
{
    public partial class App : Application
    {
        public static float ScreenWidth { get; set; }
        public static float ScreenHeight { get; set; }
        public static float originalHeight { get; set; }
        public static float adjustedHeight { get; set; }
        public static float originalWidth { get; set; }
        public static float adjustedWidth { get; set; }
        public static float androidHeightPixels { get; set; }
        public static float appScale { get; set; }
        public static int DeviceType { get; set; }
        public static bool isPhone { get; set; }
        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("name"))
            {
                Application.Current.MainPage = new SampleTabbedPage(
                    Application.Current.Properties["name"].ToString(), Application.Current.Properties["email"].ToString()
                );
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Console.WriteLine("App starts");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            //Console.WriteLine("App sleeps");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            //Console.WriteLine("App resumes");
        }
    }
}
