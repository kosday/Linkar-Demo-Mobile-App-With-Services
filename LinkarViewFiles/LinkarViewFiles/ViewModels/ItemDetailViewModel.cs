using System;

using LinkarViewFiles.Models;
using LinkarViewFiles.Services;

namespace LinkarViewFiles.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDataStore DataStore = new ItemDataStore();
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = "Item Code: " + item?.Code;
            Item = item;
        }
    }
}
