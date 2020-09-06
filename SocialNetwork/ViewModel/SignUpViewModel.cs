using SocialNetwork.Command;
using SocialNetwork.Model;
using SocialNetwork.View;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SocialNetwork.ViewModel
{
    class SignUpViewModel : ViewModelBase
    {
        SignUpView signUp;

        #region Properties
        private tblUser user;
        public tblUser User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        #endregion

        // constructor
        public SignUpViewModel(SignUpView signUpOpen)
        {
            signUp = signUpOpen;
            user = new tblUser();
        }


        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// method for enabling Save button
        /// </summary>
        /// <returns></returns>
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName)
                || String.IsNullOrEmpty(user.Username) || String.IsNullOrEmpty(user.UserPassword))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// method for adding new user 
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                using (SocialNetworkEntities context = new SocialNetworkEntities())
                {
                    tblUser newUser = new tblUser();

                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;
                    newUser.BirthDate = user.BirthDate;                    

                    newUser.Username = user.Username; 

                    if (PasswordValidation(user.UserPassword))
                    {
                        newUser.UserPassword = user.UserPassword;
                    }
                    else
                    {
                        MessageBox.Show("Wrong password. Password must have at least 8 characters.\n(1 upper char, 1 lower char, 1 number and 1 special char)\nPlease try again.");
                    }

                    newUser.UserID = user.UserID;

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("The user created successfully.");
                }
                signUp.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong inputs, please check your inputs or try again.");
            }
        }

        // command for closing the window
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// method for closing the window
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                signUp.Close();
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

        #endregion

        #region Methods

        /// <summary>
        /// method for the password validation
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool PasswordValidation(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            bool isValidated = regex.IsMatch(password);

            if (isValidated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
