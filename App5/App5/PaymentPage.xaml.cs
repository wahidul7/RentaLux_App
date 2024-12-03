using System;
using Xamarin.Forms;

namespace App5.Views
{
    public partial class PaymentPage : ContentPage
    {
        public decimal Price { get; set; } // Price of the car rental

        public PaymentPage(decimal rentalPrice)
        {
            InitializeComponent();
            Price = rentalPrice;
            BindingContext = this; // Bind the Price property
        }

        private async void OnPayClicked(object sender, EventArgs e)
        {
            // Handle payment processing here (e.g., validate fields, initiate payment)
            await DisplayAlert("Payment Success", "Your payment has been processed successfully!", "OK");

            // Optionally, navigate back or to a confirmation page
            await Navigation.PopToRootAsync();
        }
    }
}
