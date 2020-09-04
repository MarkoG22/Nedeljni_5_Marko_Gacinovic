using SocialNetwork.Model;
using SocialNetwork.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        UserView userView;

        private tblUser user;
        public tblUser User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        public UserViewModel(UserView userViewOpen)
        {
            userView = userViewOpen;
        }
    }
}
