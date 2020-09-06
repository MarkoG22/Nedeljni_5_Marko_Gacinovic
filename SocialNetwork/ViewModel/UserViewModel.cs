using SocialNetwork.Model;
using SocialNetwork.View;

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
