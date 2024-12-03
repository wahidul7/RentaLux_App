using Xamarin.Forms;
using System.IO;
using System;

namespace App5
{
    public partial class App : Application
    {
        static Database database;
        public static int CurrentUserId { get; set; }

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3");
                    database = new Database(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new IntroPage());
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
    }
}
