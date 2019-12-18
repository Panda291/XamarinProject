using System;

using XamarinProject.Models;

namespace XamarinProject.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Card Card { get; set; }
        public ItemDetailViewModel(Card card = null)
        {
            Title = card?.Name;
            Card = card;
        }
    }
}
