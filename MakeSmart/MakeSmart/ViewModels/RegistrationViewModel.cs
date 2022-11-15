using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace MakeSmart.ViewModels
{
    public class RegistrationViewModel: INotifyPropertyChanged
    {
        public RegistrationViewModel()
        {
            PostPeople = new Command(AddPerson);
        }
        public ICommand PostPeople { get; }
        string firstname;
        public string FirstName {
            get => firstname;
            set
            {
                firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public void AddPerson()
        {
            
        }
    }
}
