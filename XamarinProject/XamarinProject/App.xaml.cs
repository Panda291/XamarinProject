using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Services;
using XamarinProject.Views;
using SQLitePCL;
using System.IO;

namespace XamarinProject
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MyDataStore>();
            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        static CardDatabase database;

        public static CardDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CardDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLite.db3"));
                }
                return database;
            }
        }
    }
}
