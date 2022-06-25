using BugsBuster.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace BugsBuster
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminHomepage : TabbedPage
    {
        public AdminHomepage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                usersCV.ItemsSource = await App.MyDatabase.ReadUsers();
            }
            catch { }
        }

        async void Add_New_User(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUser());
        }

        async void Update(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var user = item.CommandParameter as RegUserTable;

            await Navigation.PushAsync(new AddUser(user));
        }

        async void Delete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var user = item.CommandParameter as RegUserTable;
            var result = await DisplayAlert("Remove User", "Are you sure you want to delete this user?", "Yes", "No");
            
            if(result)
            {
                await App.MyDatabase.DeleteUsers(user);
                usersCV.ItemsSource = await App.MyDatabase.ReadUsers();
            }
        }
    }
}