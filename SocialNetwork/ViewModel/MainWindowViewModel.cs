using SocialNetwork.Command;
using SocialNetwork.Model;
using SocialNetwork.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SocialNetwork.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        #region Properties
        // properties for username and password
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }

        private tblUser user;
        public tblUser User
        {
            get { return user; }
            set { user = value; }
        }

        #endregion

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #region Commands
        // command for the login button
        private ICommand logIn;
        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return logIn;
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        /// <summary>
        /// method for checking username and password and opening the windows
        /// </summary>
        private void SaveExecute()
        {
            if (IsUser(username, userPassword))
            {
                UserView userView = new UserView();
                userView.ShowDialog();
            }            
            else
            {
                MessageBox.Show("Wrong username or password, please try again.");
            }
        }

        // command for closing the window
        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return logout;
            }
        }

        /// <summary>
        /// method for closing the window
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                main.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }

        private bool CanSignUpExecute()
        {
            return true;
        }

        private void SignUpExecute()
        {
            SignUpView signUpView = new SignUpView();
            signUpView.ShowDialog();
        }
        #endregion

        private bool IsUser(string username, string password)
        {
            try
            {
                using (SocialNetworkEntities context = new SocialNetworkEntities())
                {
                    tblUser user = (from x in context.tblUsers where x.Username == username && x.UserPassword == password select x).First();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}
