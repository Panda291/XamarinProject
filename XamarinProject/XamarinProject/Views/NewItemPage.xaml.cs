using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Models;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Card Card { get; set; }
        private Label TypeLabel { get; set; }
        private Label AttributeLabel { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Card = new Card
            {
                Name = "Item name",
            };

            TypeLabel = new Label();
            TypeLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Type));
            AttributeLabel = new Label();
            AttributeLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Attribute));
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Card.Type = TypeLabel.Text;
            Card.Attribute = AttributeLabel.Text;
            MessagingCenter.Send(this, "AddItem", Card);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}