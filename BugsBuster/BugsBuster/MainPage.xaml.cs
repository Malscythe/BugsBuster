using BugsBuster.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BugsBuster
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        async void Sign_Up(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegistration());
        }

        async void Log_In(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UsersDB.db");
            var db = new SQLiteConnection(dbpath);
            var myQuery = db.Table <RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Text)).FirstOrDefault();

            if(myQuery!=null)
            {
                App.Current.MainPage = new NavigationPage(new AdminHomepage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Login Failed", "Username or Password is incorrect!", "Yes", "Cancel");
                });
            }

        }
    }
}
