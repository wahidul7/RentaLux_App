using System;
using Xamarin.Forms;

namespace App5.Views
{
    public partial class SignupPage : ContentPage
    {
        private Database _database;

        public SignupPage()
        {
            InitializeComponent();
            _database = App.Database;
        }

        private async void OnSignupButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var email = EmailEntry.Text;
            var phone = PhoneEntry.Text;
            var dob = DOBEntry.Date;
            var driverLicense = DriverLicenseEntry.Text;
            var firstName = FirstNameEntry.Text;
            var lastName = LastNameEntry.Text;
            var termsAccepted = TermsCheckBox.IsChecked;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && termsAccepted)
            {
                var newUser = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    Phone = phone,
                    DateOfBirth = dob,
                    DriverLicense = driverLicense,
                    FirstName = firstName,
                    LastName = lastName
                };
                await _database.AddUserAsync(newUser);
                await DisplayAlert("Success", "User registered successfully", "OK");
                await Navigation.PushAsync(new WelcomePage());
            }
            else
            {
                await DisplayAlert("Error", "Please fill in all fields and accept the terms and conditions", "OK");
            }
        }
    }
}
