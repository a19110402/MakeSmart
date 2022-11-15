using MakeSmart.DataBinding;
using MakeSmart.Services;
using MakeSmart.Tables;
using MakeSmart.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeSmart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage(IOAuth2Service oAuth2Service)
        {
            InitializeComponent();
             
            this.BindingContext = new SocialLoginPageViewModel(oAuth2Service);
            //this.BindingContext = new LoginViewModel();
        }
        private async void Handle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
            //MainPage = new RegistrationPage();
        }
        async void Handle_Clicked_SignUp(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new AppShell();
                //App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed User Name and Password", "Yes", "Cancel");

                    //if (result)
                    //    await Navigation.PushAsync(new HomePage());
                    //else
                    //{
                    //    await Navigation.PushAsync(new RegistrationPage());
                    //}
                });
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}