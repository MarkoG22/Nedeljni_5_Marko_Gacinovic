using SocialNetwork.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SocialNetwork.View
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        public SignUpView()
        {
            InitializeComponent();
            this.DataContext = new SignUpViewModel(this);
        }

        /// <summary>
        /// method for textbox text validations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LettersValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
