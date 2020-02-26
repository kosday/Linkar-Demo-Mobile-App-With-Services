using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LinkarViewFiles.Models;

namespace LinkarViewFiles.Services
{
    public class LoginDataStore
    {        
        HttpClient client;

        public LoginDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.servicesUrl}/");
        }

        public async Task<Login> LoginAsync()
        {
            var json = await client.GetStringAsync($"api/Linkar/Login?user=linkar&pass=linkar");
            return await Task.Run(() => JsonConvert.DeserializeObject<Login>(json));
        }

        public async Task<string> LogoutAsync()
        {
            if (App.Token != null)
            {
                var json = await client.GetStringAsync($"api/Linkar/Logout?token=" + App.Token);
                return await Task.Run(() => JsonConvert.DeserializeObject<string>(json));
            }

            return null;
        }
    }
}