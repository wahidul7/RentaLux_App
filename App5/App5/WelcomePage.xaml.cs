using System;
using Xamarin.Forms;

namespace App5.Views
{
    public partial class WelcomePage : ContentPage
    {
        private Database _database;

        public WelcomePage()
        {
            InitializeComponent();
            _database = App.Database; // Initialize the _database field
        }

        // Handles the login button click event
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            // Check if username and password are provided
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Attempt to retrieve user from the database
                var user = await _database.GetUserAsync(username, password);
                if (user != null)
                {
                    // Successful login
                    await DisplayAlert("Success", "Login successful", "OK");

                    // Set the current user ID
                    App.CurrentUserId = user.ID;

                    // Navigate to MainPage with the user data
                    await Navigation.PushAsync(new MainPage(user));
                }
                else
                {
                    // Invalid credentials
                    await DisplayAlert("Error", "Invalid username or password", "OK");
                }
            }
            else
            {
                // Missing username or password
                await DisplayAlert("Error", "Please fill in all fields", "OK");
            }
        }

        // Handles the continue as guest option
        private async void OnContinueAsGuestTapped(object sender, EventArgs e)
        {
            // Navigate to MainPage as a guest
            await Navigation.PushAsync(new IntroPage());
        }

        // Handles the create an account option
        private async void OnCreateAnAccountTapped(object sender, EventArgs e)
        {
            // Navigate to SignupPage
            await Navigation.PushAsync(new SignupPage());
        }
    }
}
