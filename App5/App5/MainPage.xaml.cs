using System;
using App5.Views;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public MainPage(User user)
        {
            InitializeComponent(); BindingContext = user;}
        private async void OnUserProfileClicked(object sender, EventArgs e)
        {
            // Fetch current user data using their ID
            var user = await App.Database.GetUserByIdAsync(App.CurrentUserId); // Ensure App.CurrentUserId is set appropriately
            await Navigation.PushAsync(new UserProfilePage(user));
        }

        private async void OnStartRentingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarSelectionPage());
        }
    }
}
