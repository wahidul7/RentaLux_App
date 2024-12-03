using Xamarin.Forms;
using System.Collections.ObjectModel;
using App5.Models;
using System;
using App5.Views;

namespace App5.Views
{
    public partial class CarListPage : ContentPage
    {
        public CarListPage(string carType)
        {
            InitializeComponent();
            PageTitle = $"{carType} Cars Available";
            Cars = GetCarsByType(carType);
            BindingContext = this;
        }

        public string PageTitle { get; set; }
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();

        private ObservableCollection<Car> GetCarsByType(string carType)
        {
            var cars = new ObservableCollection<Car>();

            if (carType == "Standard")
            {
                cars.Add(new Car { Name = "Toyota Corolla", Photo = "corola.avif", Description = "A reliable and fuel-efficient car perfect for city driving." });
                cars.Add(new Car { Name = "Honda Civic", Photo = "civic.png", Description = "A compact car with great handling and fuel economy." });
            }
            else if (carType == "Luxury")
            {
                cars.Add(new Car { Name = "Mercedes-Benz S-Class", Photo = "marcedis.webp", Description = "Luxury at its finest with top-of-the-line comfort." });
                cars.Add(new Car { Name = "BMW 7 Series", Photo = "bmw.webp", Description = "A high-end car with impressive performance and luxury." });
            }
            else if (carType == "Economy")
            {
                cars.Add(new Car { Name = "Nissan Versa", Photo = "nissan.jpg", Description = "Affordable and fuel-efficient, ideal for budget-conscious renters." });
                cars.Add(new Car { Name = "Hyundai Accent", Photo = "hyundai.jpg", Description = "A small, efficient car that's perfect for daily commuting." });
            }

            return cars;
        }

        private async void OnCarTapped(object sender, EventArgs e)
        {
            // Retrieve the car that was tapped
            var tappedCar = (sender as VisualElement).BindingContext as Car;

            if (tappedCar != null)
            {
                // Navigate to CarDetailPage, passing the selected car
                await Navigation.PushAsync(new CarDetails(tappedCar));
            }
        }
    }
}
