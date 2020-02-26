using System;

using LinkarViewFiles.Models;
using LinkarViewFiles.Services;

namespace LinkarViewFiles.ViewModels
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        public CustomerDataStore DataStore = new CustomerDataStore();

        public Customer Customer { get; set; }
        public CustomerDetailViewModel(Customer customer = null)
        {
            Title = "Customer Code: " + customer?.Code;
            Customer = customer;
        }
    }
}
