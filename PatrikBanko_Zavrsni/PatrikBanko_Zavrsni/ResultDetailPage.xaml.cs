
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PatrikBanko_Zavrsni
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultDetailPage : ContentPage
    {
        public ResultDetailPage(ModelResults SelectedResult)
        {
            InitializeComponent();
        }
    }
}