using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace MakeSmart.DataBinding
{
    public class BindingRegister : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _viewModelText;
        private Boolean _fieldAllRight = false;
        string UserName = string.Empty;
        string password = string.Empty;
        string email = string.Empty;
        string phoneNumber = string.Empty;
        public string name = "";

        public string Nombre { get; set; }

        public Boolean FieldAllRight
        {
            get
            {
                return _fieldAllRight;
            }
            set
            {
                _fieldAllRight = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FieldAllRight)));
                }
            }
        }
        public string ViewModelText
        {
            get
            {
                return _viewModelText;
            }
            set
            {
                _viewModelText = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ViewModelText)));
                }
            }
        }
        void onPropertyChanged(string userName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(userName));
        }
        public void ValidateFields(string userName, string email, string password, string rpasword, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(phoneNumber) &&
                !string.IsNullOrEmpty(email) && IsValidEmail(email) && password.Length < 8 && IsValidPass(password, rpasword) &&
                phoneNumber.Length == 10)
            {
                _fieldAllRight = true;
                ViewModelText = "Smn";
            } else
            {
                _fieldAllRight = false;
                ViewModelText = "Nel";
            }
        }
        static bool IsValidPass(string pasword, string rpassword)
        {
            bool sssss = Regex.IsMatch(pasword, @"[A-Z]");
            bool especial = Regex.IsMatch(pasword, @"[$&+,:;=?@#|'<>.^*()%!-]");
            bool num = Regex.IsMatch(pasword, @"[0-9]");
            if (Regex.IsMatch(pasword, @"[A-Z]") && Regex.IsMatch(pasword, @"[$&+,:;=?@#|'<>.^*()%!-]") 
                && Regex.IsMatch(pasword, @"[0-9]") && string.Equals(pasword, rpassword))
            {
                return true;
            } else
            {
                return false;
            }
        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
