using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using LinkarViewFiles.Models;
using LinkarViewFiles.Views;
using System.Net.Http;
using LinkarViewFiles.Services;

namespace LinkarViewFiles.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemDataStore DataStore = new ItemDataStore();
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Items";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var customers = await DataStore.GetItemsAsync(true);
                foreach (var item in customers)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}