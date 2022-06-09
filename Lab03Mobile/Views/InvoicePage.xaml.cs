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
        public ObservableCollection<Car> Cars { get; set; }
        public Invoice Invoices { get; set; }

        public InvoicePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            this.Cars = new ObservableCollection<Car>(CarDbContext.CarList.Where(car => car.Disponible == false));
            this.rentedCarCollectionView.ItemsSource = this.Cars;

            this.Invoices = CarDbContext.invoice;
            this.invoiceAmount.Text = $"Montant de la facture ${this.Invoices.Amount}";
        }

        private void Btn_Return_Car_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Car car = btn.BindingContext as Car;

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
            await Navigation.PushModalAsync(new InvoiceModalPage(Invoices));
        }
    }
}