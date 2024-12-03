using System;
using Xamarin.Forms;

namespace App5
{
    public partial class EditProfilePage : ContentPage
    {
        private User _user;
        private Database _database;

        public EditProfilePage(User user)
        {
            InitializeComponent();
            _database = App.Database; // Use the App's database instance
            _user = user;
            BindingContext = _user; // Bind user data to the page
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            await _database.SaveUserAsync(_user); // Save the updated user data
            await DisplayAlert("Success", "Profile updated successfully", "OK");
            await Navigation.PopAsync(); // Go back to the previous page
        }
    }
}
