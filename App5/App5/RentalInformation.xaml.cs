using System;
using Xamarin.Forms;

namespace App5.Views
{
    public partial class RentalInformation : ContentPage
    {
        private const decimal dailyRate = 90.00m;

        public RentalInformation()
        {
            InitializeComponent();
            SetupPickupLocationPicker(); // Initialize the Picker with locations
        }

        private void SetupPickupLocationPicker()
        {
            pickupLocationPicker.Items.Clear(); // Clear any existing items
            pickupLocationPicker.Items.Add("Toronto");
            pickupLocationPicker.Items.Add("Scarborough");
            pickupLocationPicker.Items.Add("North York");
            pickupLocationPicker.Items.Add("Brampton");
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            CalculatePriceEstimate();
        }

        private void CalculatePriceEstimate()
        {
            if (pickUpDatePicker.Date != null && returnDatePicker.Date != null)
            {
                var rentalDuration = (returnDatePicker.Date - pickUpDatePicker.Date).Days;

                if (rentalDuration > 0)
                {
                    var totalPrice = rentalDuration * dailyRate;
                    priceEstimate.Text = $"${totalPrice:0.00}";
                }
                else
                {
                    priceEstimate.Text = "Invalid dates selected";
                }
            }
        }

        private async void OnPaymentButtonClicked(object sender, EventArgs e)
        {
            if (pickUpDatePicker.Date != null && returnDatePicker.Date != null)
            {
                var rentalDuration = (returnDatePicker.Date - pickUpDatePicker.Date).Days;

                if (rentalDuration > 0)
                {
                    var totalPrice = rentalDuration * dailyRate;
                    await Navigation.PushAsync(new PaymentPage(totalPrice));
                }
                else
                {
                    await DisplayAlert("Error", "Invalid dates selected", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please select pickup and return dates", "OK");
            }
        }
    }
}
