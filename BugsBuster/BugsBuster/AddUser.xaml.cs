using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BugsBuster
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        public AddUser()
        {
            InitializeComponent();
        }

        Tables.RegUserTable _users;

        public AddUser(Tables.RegUserTable users)
        {
            InitializeComponent();
            Title = "Update User Account";
            _users = users;
            Button1.Text = "Update";
            txtFirstName.Text = users.FirstName;
            txtLastName.Text = users.LastName;
            txtEmail.Text = users.Email;
            txtPassword.Text = users.Password;
            txtUsername.Text = users.UserName;
            txtContactNo.Text = users.ContactNo;
            txtFirstName.Focus();
        }

        private async void Add_User(object sender, EventArgs e)
        {
            if(_users != null)
            {
                _users.FirstName = txtFirstName.Text;
                _users.LastName = txtLastName.Text;
                _users.Email = txtEmail.Text;
                _users.UserName = txtUsername.Text;
                _users.Password = txtPassword.Text;
                _users.ContactNo = txtContactNo.Text;

                await App.MyDatabase.UpdateUsers(_users);
                await Navigation.PopAsync();
            } 
            else
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
}