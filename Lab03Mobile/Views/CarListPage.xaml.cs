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
        public ObservableCollection<Car> Cars { get; private set; }
        public Invoice Invoices { get; set; }
        public CarListPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            this.Cars = new ObservableCollection<Car>(CarDbContext.CarList);
            this.carCollectionView.ItemsSource = Cars;
            this.Invoices = CarDbContext.invoice;
            OnPropertyChanged(nameof(Cars));
        }

        private async void Btn_Louee_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Car car = btn.BindingContext as Car;

            if (car != null)
            {
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
            Button button = sender as Button;
            Car car = button.BindingContext as Car;
            Car selectedCar = Cars[car.Id];

            CarDetailsPage carDetailsPage = new CarDetailsPage();
            carDetailsPage.BindingContext = selectedCar;
            await this.Navigation.PushAsync(carDetailsPage);
        }
    }
}