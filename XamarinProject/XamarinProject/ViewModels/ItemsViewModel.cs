using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinProject.Models;
using XamarinProject.Views;

namespace XamarinProject.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Card> Cards { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Cards = new ObservableCollection<Card>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Card>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Card;
                await DataStore.AddItemAsync(newItem);
                Cards.Add(newItem);
            });

            MessagingCenter.Subscribe<ItemDetailPage, int>(this, "RemoveItem", async (obj, id) =>
            {
                var toRemoveItem = Cards.FirstOrDefault(arg => arg.Id == id);
                await DataStore.DeleteItemAsync(id);
                Cards.Remove(toRemoveItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Cards.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Cards.Add(item);
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