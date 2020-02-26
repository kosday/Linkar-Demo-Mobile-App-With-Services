using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LinkarViewFiles.Models;

namespace LinkarViewFiles.Services
{
    public class OrderDataStore
    {
        HttpClient client;
        IEnumerable<Order> orders;

        public OrderDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.servicesUrl}/");

            orders = new List<Order>();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                var json = await client.GetStringAsync($"api/Linkar/GetOrders?token=" + App.Token);
                orders = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Order>>(json));
            }

            return orders;
        }

        public async Task<Order> GetOrderAsync(string id)
        {
            if (id != null)
            {
                var json = await client.GetStringAsync($"api/Linkar/GetOrder?token=" + App.Token + "&code=" + id);
                return await Task.Run(() => JsonConvert.DeserializeObject<Order>(json));
            }

            return null;
        }
    }
}