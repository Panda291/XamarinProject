using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XamarinProject.Models;

namespace XamarinProject.Services
{
    public class MyDataStore : IDataStore<Card>
    {
        readonly List<Card> _items;
        public MyDataStore()
        {
            _items = App.Database.GetItemAsync().Result;
        }

        public async Task<bool> AddItemAsync(Card card)
        {
            _items.Add(card);

            await App.Database.SaveItemAsync(card);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Card card)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == card.Id);
            _items.Remove(oldItem);
            _items.Add(card);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == id);
            _items.Remove(oldItem);
            await App.Database.DeleteItemAsync(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Card> GetItemAsync(int id)
        {
            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Card>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}
