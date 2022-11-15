using MakeSmart.DataBinding;
using MakeSmart.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeSmart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        BindingRegister viewModel = new BindingRegister();
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            };
            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulation", "User Registration Sucessfull", "Yes", "Cancel");

                if (result)
                    await Navigation.PushAsync(new LoginPage());
            });
        }
        public void Field_Changed(object sender, EventArgs e)
        {
            viewModel.ValidateFields(EntryUserName.Text, EntryUserEmail.Text, EntryUserPassword.Text,
                                     EntryRepeatPassword.Text, EntryUserPhoneNumber.Text);
            //viewModel.ViewModelText = $"El usuario ingresado es: {EntryUserName.Text}";
        }
    }
}
