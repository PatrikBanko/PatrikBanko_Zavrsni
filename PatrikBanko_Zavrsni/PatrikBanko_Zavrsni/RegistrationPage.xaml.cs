using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatrikBanko_Zavrsni
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        IAuth auth;
        public RegistrationPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(EntryUserEmail.Text, EntryUserPassword.Text);
            if (user != null)
            {
                await DisplayAlert("Success", "New user created", "OK");
                var signOut = auth.SignOut();
                if (signOut != false)
                {
                    Application.Current.MainPage = new LoginPage();
                }
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong, please try again", "OK");
            }

        }
    }
}