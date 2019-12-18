using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using XamarinProject.Models;

namespace XamarinProject.Services
{
    public class CardDatabase
    {
        private readonly SQLite.SQLiteAsyncConnection _database;
        public CardDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Card>().Wait();
        }

        public Task<List<Card>> GetItemAsync()
        {
            return _database.Table<Card>().ToListAsync();
        }

        public Task<Card> GetItemAsync(int id)
        {
            return _database.Table<Card>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Card card)
        {
            if (card.Id != 0)
            {
                return _database.UpdateAsync(card);
            }
            else
            {
                return _database.InsertAsync(card);
            }
        }

        public Task<int> DeleteItemAsync(Card card)
        {
            return _database.DeleteAsync(card);
        }
    }
}
