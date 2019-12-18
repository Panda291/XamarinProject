using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinProject.Models;

namespace XamarinProject.Services
{
    public class MockDataStore : IDataStore<Card>
    {
        readonly List<Card> cards;

        public MockDataStore()
        {
            cards = new List<Card>()
            {
                new Card { Name = "First item", Type="This is an item description." },
                new Card { Name = "Second item", Type="This is an item description." },
                new Card { Name = "Third item", Type="This is an item description." },
                new Card { Name = "Fourth item", Type="This is an item description." },
                new Card { Name = "Fifth item", Type="This is an item description." },
                new Card { Name = "Sixth item", Type="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Card card)
        {
            cards.Add(card);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Card card)
        {
            var oldItem = cards.Where((Card arg) => arg.Id == card.Id).FirstOrDefault();
            cards.Remove(oldItem);
            cards.Add(card);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = cards.Where((Card arg) => arg.Id == id).FirstOrDefault();
            cards.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Card> GetItemAsync(int id)
        {
            return await Task.FromResult(cards.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Card>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(cards);
        }
    }
}