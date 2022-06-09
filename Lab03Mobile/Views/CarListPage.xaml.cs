using Lab03Mobile.Data;
using Lab03Mobile.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab03Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarListPage : ContentPage
    {
        //Use to access the Cars list from the CarDbContext
        public ObservableCollection<Car> Cars { get; private set; }

        //Use to access the invoice models
        public Invoice Invoices { get; set; }
        public CarListPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {   
            //On page appearing get the car from the DbContext then define the car collection view item source
            this.Cars = new ObservableCollection<Car>(CarDbContext.CarList);
            this.carCollectionView.ItemsSource = Cars;

            //Get the Invoice from the DbContext
            this.Invoices = CarDbContext.invoice;
            OnPropertyChanged(nameof(Cars));
        }

        private async void Btn_Louee_Clicked(object sender, EventArgs e)
        {
            //Get the car id
            Button btn = sender as Button;
            Car car = btn.BindingContext as Car;

            if (car != null)
            {
                //If the car is available notify the user of success, set the car to unavailable and add the price to the invoice
                //Otherwise notify the user that the car is not available
                if (car.Disponible == true)
                {
                    await DisplayAlert("Information", $"Vous avez fait la location du vehicule suivant: {car.Modele}", "Ok");
                    car.Disponible = false;
                    Invoices.Amount += car.PrixJours;
                }
                else
                    await DisplayAlert("Information", $"Le vehicule selectionnée n'ai pas disponible", "Ok");
            }
        }

        private async void Btn_Details_Clicked(object sender, EventArgs e)
        {
            //Get the car object
            Button button = sender as Button;
            Car car = button.BindingContext as Car;
            Car selectedCar = Cars[car.Id];

            //Create a CarDetailsPage, bind the page to the car then navigate to the car details page
            CarDetailsPage carDetailsPage = new CarDetailsPage();
            carDetailsPage.BindingContext = selectedCar;
            await this.Navigation.PushAsync(carDetailsPage);
        }
    }
}