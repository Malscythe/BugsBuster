using BugsBuster.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BugsBuster
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegistration : ContentPage
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        async void Register(object sender, EventArgs e)
        {
            
            await App.MyDatabase.CreateUser(new Tables.RegUserTable
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
                ContactNo = txtContactNo.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            });

            await Navigation.PopAsync();
        }
    }
}