using System;
using System.ComponentModel;
using SQLite;

namespace App5.Models
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private string _username;
        private string _email;
        private string _phone;
        private DateTime _dateOfBirth;
        private string _driverLicense;
        private string _firstName;
        private string _lastName;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); }
        }

        public string DriverLicense
        {
            get => _driverLicense;
            set { _driverLicense = value; OnPropertyChanged(nameof(DriverLicense)); }
        }

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
