using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatrikBanko_Zavrsni
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        IAuth auth;
        public LoginPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();
            if (signOut)
            {
                Application.Current.MainPage = new RegistrationPage();
            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(EntryEmail.Text, EntryPassword.Text);
            if (token != "")
            {
                Application.Current.MainPage = new TabbedPage1();
            }
            else
            {
                await DisplayAlert("Authentication failed", "Email or password are incorrect", "OK");
            }

        }
    }
}