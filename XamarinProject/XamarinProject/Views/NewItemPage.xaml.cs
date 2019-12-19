using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Security;
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
        private Label RarityLabel { get; set; }
        private Label QualityLabel { get; set; }
        
        private bool Cancel { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Card = new Card
            {
            };

            TypeLabel = new Label();
            TypeLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Type));
            AttributeLabel = new Label();
            AttributeLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Attribute));
            RarityLabel = new Label();
            RarityLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Rarity));
            QualityLabel = new Label();
            QualityLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Quality));
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Cancel = false;
            Card.Type = TypeLabel.Text;
            Card.Attribute = AttributeLabel.Text;
            Card.Rarity = RarityLabel.Text;
            Card.Quality = QualityLabel.Text;
            if (IsValidLevel(Card.Level) != 0)
            {
                Level.BackgroundColor = Color.Red;
                Cancel = true;
            } else Level.BackgroundColor = Color.Default;

            if (!IsValidAmount(Card.Amount))
            {
                Amount.BackgroundColor = Color.Red;
                Cancel = true;
            } else Amount.BackgroundColor = Color.Default;
            
            if (Card.Type == null)
            {
                Type.BackgroundColor = Color.Red;
                Cancel = true;
            } else Type.BackgroundColor = Color.Default;
            
            if (Card.Attribute == null)
            {
                Attribute.BackgroundColor = Color.Red;
                Cancel = true;
            } else Attribute.BackgroundColor = Color.Default;

            if (Card.Quality == null)
            {
                Quality.BackgroundColor = Color.Red;
                Cancel = true;
            } else Quality.BackgroundColor = Color.Default;
            
            if (Card.Rarity == null)
            {
                Rarity.BackgroundColor = Color.Red;
                Cancel = true;
            } else Rarity.BackgroundColor = Color.Default;
            
            if (string.IsNullOrEmpty(Card.Name))
            {
                Name.BackgroundColor = Color.Red;
                Cancel = true;
            } else Name.BackgroundColor = Color.Default;

            if (!Cancel)
            {
                MessagingCenter.Send(this, "AddItem", Card);
                await Navigation.PopModalAsync();
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        int IsValidLevel(int Lvl)
        {
            if (Lvl < 0) return -1;
            if (Lvl > 12) return 1;
            return 0;
        }

        bool IsValidAmount(int Amount)
        {
            if (Amount <= 0) return false;
            return true;
        }
    }
}