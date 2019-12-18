﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Models;
using XamarinProject.ViewModels;
using XamarinProject;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        readonly ItemDetailViewModel _viewModel;
        public Card Card { get; set; }
        private int _Id { get; }

        public ItemDetailPage(ItemDetailViewModel viewModel, int id)
        {
            InitializeComponent();
            _Id = id;
            BindingContext = this._viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            Card = new Card
            {
                Name = "Item 1",
                Type = "This is an item description."
            };

            _viewModel = new ItemDetailViewModel(Card);
            BindingContext = _viewModel;
        }

        async void Remove_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "RemoveItem", _Id);
            await Navigation.PopAsync();
        }
    }
}