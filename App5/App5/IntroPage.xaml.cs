using App5.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private async void OnLetsGoClicked(object sender, EventArgs e)
        {
            // Navigate to the Welcome page after clicking "Let's Go!"
            await Navigation.PushAsync(new WelcomePage());
        }
    }
}