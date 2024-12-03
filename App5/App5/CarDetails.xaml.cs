using App5.Models;
using App5.Models;
using System;
using Xamarin.Forms;

namespace App5.Views
{
    public partial class CarDetails : ContentPage
    {
        public CarDetails(Car selectedCar)
        {
            InitializeComponent();

            // Set BindingContext to the selected car
            BindingContext = selectedCar;
        }

        private async void OnRentCarClicked(object sender, EventArgs e)
        {
            // Navigate to RentCarPage when the button is clicked
            await Navigation.PushAsync(new RentalInformation());
        }
    }
}
