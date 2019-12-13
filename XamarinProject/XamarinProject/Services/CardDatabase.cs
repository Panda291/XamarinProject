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
        SQLite.SQLiteAsyncConnection database;
        public CardDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(int id)
        {
            return database.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item card)
        {
            if (card.Id != 0)
            {
                return database.UpdateAsync(card);
            }
            else
            {
                return database.InsertAsync(card);
            }
        }
    }
}
