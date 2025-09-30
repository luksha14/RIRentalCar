using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RIRentalCar
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly string _username = "ridevoyage";
        private readonly string _password = "123";
        private readonly Page _nextPage;

        public LoginPage(Page nextPage)
        {
            InitializeComponent();
            _nextPage = nextPage;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == _username && PasswordBox.Password == _password)
            {
                var parentWindow = Window.GetWindow(this) as MainWindow;
                parentWindow?.MainFrame.Navigate(_nextPage);
            }
            else
            {
                ErrorMessage.Text = "Incorrect username or password.";
            }
        }

        private void BackToMainPageButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new MainMenu());
        }
    }

}
