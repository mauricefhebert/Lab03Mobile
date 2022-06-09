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
        //Use to access the Invoice passed as a parameter
        public Invoice Invoices { get; set; }
        public InvoiceModalPage(Invoice invoice)
        {
            InitializeComponent();
            //Assign the invoice passed as a parameter to the access method
            Invoices = invoice;
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Fill the entry with the amount of the invoice
            this.invoiceAmountEntry.Text = Invoices.Amount.ToString();
        }

        private void Btn_Confirm_Payement_Clicked(object sender, EventArgs e)
        {
            //If the amount in the entry is greater then zero substract the invoice with the entry amount
            //Then return to the invoice page
            double amountPayed = double.Parse(this.invoiceAmountEntry.Text);
            if(amountPayed > 0)
                this.Invoices.Amount -= amountPayed;

            Navigation.PopModalAsync();
        }

        private async void Btn_Cancel_Payement_Clicked(object sender, EventArgs e)
        {
            //If the use press cancel close the modal
            await Navigation.PopModalAsync();
        }
    }
}