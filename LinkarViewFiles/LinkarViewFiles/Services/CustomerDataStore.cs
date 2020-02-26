using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LinkarViewFiles.Models;

namespace LinkarViewFiles.Services
{
    public class CustomerDataStore
    {
        HttpClient client;
        IEnumerable<Customer> customers;

        public CustomerDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.servicesUrl}/");

            customers = new List<Customer>();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                var json = await client.GetStringAsync($"api/Linkar/GetCustomers?token=" + App.Token);
                customers = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Customer>>(json));
            }

            return customers;
        }

        public async Task<Customer> GetCustomerAsync(string id)
        {
            if (id != null)
            {
                var json = await client.GetStringAsync($"api/Linkar/GetCustomer?token=" + App.Token + "&code=" + id);
                return await Task.Run(() => JsonConvert.DeserializeObject<Customer>(json));
            }

            return null;
        }
    }
}