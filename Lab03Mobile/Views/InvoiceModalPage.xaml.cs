using Lab03Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab03Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceModalPage : ContentPage
    {
        public Invoice Invoices { get; set; }
        public InvoiceModalPage(Invoice invoice)
        {
            InitializeComponent();
            Invoices = invoice;
            this.BindingContext = Invoices;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string amount = $"Montant de la facture ${this.Invoices.Amount}";
            this.invoiceAmountEntry.Text = amount;
        }

        private void Btn_Confirm_Payement_Clicked(object sender, EventArgs e)
        {
            double amountPayed = double.Parse(this.invoiceAmountEntry.Text);

            if(amountPayed > 0)
                this.Invoices.Amount -= amountPayed;

            Navigation.PopModalAsync();
        }

        private async void Btn_Cancel_Payement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}