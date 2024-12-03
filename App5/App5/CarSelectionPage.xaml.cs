using System;
using Xamarin.Forms;

namespace App5.Views
{
    public partial class CarSelectionPage : ContentPage
    {
        public CarSelectionPage()
        {
            InitializeComponent();
        }

        private async void OnStandardTapped(object sender, EventArgs e)
        {
            // Navigate to StandardCarDetailsPage
            await Navigation.PushAsync(new CarListPage("Standard"));
        }

        private async void OnEconomyTapped(object sender, EventArgs e)
        {
            // Navigate to EconomyCarDetailsPage
            await Navigation.PushAsync(new CarListPage("Economy"));
        }

        private async void OnLuxuryTapped(object sender, EventArgs e)
        {
            // Navigate to LuxuryCarDetailsPage
            await Navigation.PushAsync(new CarListPage("Luxury"));
        }

    }
}
