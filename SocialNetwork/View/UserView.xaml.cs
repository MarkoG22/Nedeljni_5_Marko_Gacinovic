using SocialNetwork.ViewModel;
using System.Windows;

namespace SocialNetwork.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this);
        }
    }
}
