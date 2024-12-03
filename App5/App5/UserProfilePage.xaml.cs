using System;
using Xamarin.Forms;

namespace App5
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage(User user)
        {
            InitializeComponent();
            BindingContext = user; // Set the BindingContext to the User object
        }

        private async void OnEditProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage(BindingContext as User));
        }

        private async void OnDeleteProfileClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirm", "Are you sure you want to delete your profile?", "Yes", "No");
            if (confirm)
            {
                var user = BindingContext as User;
                await App.Database.DeleteUserAsync(user);
                await DisplayAlert("Deleted", "Your profile has been deleted", "OK");
                await Navigation.PopToRootAsync();
            }
        }
    }
}
