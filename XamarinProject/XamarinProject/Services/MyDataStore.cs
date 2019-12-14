using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XamarinProject.Models;

namespace XamarinProject.Services
{
    public class MyDataStore : IDataStore<Item>
    {
        readonly List<Item> _items;
        public MyDataStore()
        {
            _items = App.Database.GetItemAsync().Result;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
//            _items.Add(item);

            await App.Database.SaveItemAsync(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(oldItem);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == id);
            _items.Remove(oldItem);
            await App.Database.DeleteItemAsync(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}
