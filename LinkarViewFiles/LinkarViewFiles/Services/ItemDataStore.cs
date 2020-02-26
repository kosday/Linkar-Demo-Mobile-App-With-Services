using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LinkarViewFiles.Models;

namespace LinkarViewFiles.Services
{
    public class ItemDataStore
    {
        HttpClient client;
        IEnumerable<Item> items;

        public ItemDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.servicesUrl}/");

            items = new List<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                var json = await client.GetStringAsync($"api/Linkar/GetItems?token=" + App.Token);
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return items;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null)
            {
                var json = await client.GetStringAsync($"api/Linkar/GetItem?token=" + App.Token + "&code=" + id);
                return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }

            return null;
        }
    }
}