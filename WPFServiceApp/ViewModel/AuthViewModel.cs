using DapperDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFServiceApp.Model;
using WPFServiceApp.View;
using WPFServiceApp.View.ViewModel;

namespace WPFServiceApp.ViewModel
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private AuthWindow authWindow;

        private string loginStr;
        public string LoginStr
        {
            get { return loginStr; }
            set { loginStr = value; OnPropertyChanged("LoginStr"); }
        }

        private string passStr;
        public string PassStr
        {
            get { return passStr; }
            set { passStr = value; OnPropertyChanged("PassStr"); }
        }

        private string nameStr;
        public string NameStr
        {
            get { return nameStr; }
            set { nameStr = value; OnPropertyChanged("NameStr"); }
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(obj =>
                {
                    if (authWindow.nameLabel.Visibility != Visibility.Visible)
                        MessageBox.Show(Logic.Auth(new WUser() { WUser_Login = LoginStr, WUser_Hashpass = PassStr }));
                    else
                    {
                        authWindow.nameLabel.Visibility = Visibility.Collapsed;
                        authWindow.nameTextBox.Visibility = Visibility.Collapsed;
                    }
                }));
            }
        }

        private RelayCommand regCommand;
        public RelayCommand RegCommand
        {
            get
            {
                return regCommand ?? (regCommand = new RelayCommand(obj =>
                {
                    if (authWindow.nameLabel.Visibility == Visibility.Visible)
                        Logic.Reg(new WUser() { WUser_Name = NameStr, WUser_Login = LoginStr, WUser_Hashpass = PassStr });
                    else
                    {
                        authWindow.nameLabel.Visibility = Visibility.Visible;
                        authWindow.nameTextBox.Visibility = Visibility.Visible;
                    }
                }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public AuthViewModel(AuthWindow authWindow) => this.authWindow = authWindow;
    }
}
