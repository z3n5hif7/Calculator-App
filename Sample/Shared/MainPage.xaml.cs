using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            NameEntry.Text = "Name";
            EmailEntry.Text = "Email@gmail.com";
            PasswordEntry.Text = "TabbedPage";
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(NameEntry.Text) && !string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
            {
                Xamarin.Forms.Application.Current.Properties["name"] = NameEntry.Text;
                Xamarin.Forms.Application.Current.Properties["email"] = EmailEntry.Text;
                Xamarin.Forms.Application.Current.SavePropertiesAsync();

                Xamarin.Forms.Application.Current.MainPage = new SampleTabbedPage(NameEntry.Text, EmailEntry.Text);
                /*
                //Use this if you want the master detail page
                Application.Current.MainPage = new MainMasterDetailPage(NameEntry.Text, EmailEntry.Text); 
                */
            }
            else
            {
                bool retryBool = await DisplayAlert("Error", "Please fill in all fields. Retry?", "Yes","No");
                if (retryBool)
                {
                    NameEntry.Text = string.Empty;
                    EmailEntry.Text = string.Empty;
                    PasswordEntry.Text = string.Empty;
                    NameEntry.Focus();
                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            //logo.Rotation = 90;//animation without time
            //await logo.RotateTo(90, 5000);//animation with time

            //logo.Scale = 2;//animation without time
            //await logo.ScaleTo(2, 5000);//animation with time

            //logo.TranslationX = 50;//animation without time
            //logo.TranslationY = 50;//animation without time
            //await logo.TranslateTo(50, 50, 5000);//animation with time

            //logo.Opacity = 0.5;//animation without time
            //await logo.FadeTo(0.1, 5000);//animation with time
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //NameEntry.Text = string.Empty;
            //EmailEntry.Text = string.Empty;
            //PasswordEntry.Text = string.Empty;
        }

        private async void SignUp_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignupPage(), true);
            //await Navigation.PushAsync(new SignupPage(), false);
        }
    }
}
