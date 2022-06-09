using Lab03Mobile.Data;
using Lab03Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab03Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoicePage : ContentPage
    {
        //Use to access the car list in the DbContext
        public ObservableCollection<Car> Cars { get; set; }
        //Use to access the invoice from the DbContext
        public Invoice Invoices { get; set; }

        public InvoicePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            //Return the list of car the are not avvailable then set it as the rentedCar collection view item source
            this.Cars = new ObservableCollection<Car>(CarDbContext.CarList.Where(car => car.Disponible == false));
            this.rentedCarCollectionView.ItemsSource = this.Cars;

            //Get the Invoice from the DbContext and use it to display the amount that need to be payed
            this.Invoices = CarDbContext.invoice;
            this.invoiceAmount.Text = $"Montant de la facture ${this.Invoices.Amount}";
        }

        private void Btn_Return_Car_Clicked(object sender, EventArgs e)
        {
            //Get the car object
            Button btn = sender as Button;
            Car car = btn.BindingContext as Car;

            //Notify the use that the car was return, set the car to available
            //if the invoice amount is greater then 0 then substract the car value from the invoice
            if (car != null)
            {
                DisplayAlert("Confirmation", $"Vous avez retourn le vehicule suivant: {car.Modele}", "Ok");
                car.Disponible = true;
                if(Invoices.Amount > 0)
                    this.Invoices.Amount -= car.PrixJours;
            }
        }

        private async void Btn_Paye_Invoice_Clicked(object sender, EventArgs e)
        {
            //Open a modal and pass the invoice as a parameter to be able to paye the invoice
            await Navigation.PushModalAsync(new InvoiceModalPage(Invoices));
        }
    }
}