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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new LoginPage(new AddCarPage()));
        }

        private void ReservationButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainFrame.Navigate(new CarReservationPage());
            }
        }

        private void ShowCarsButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainFrame.Navigate(new CarListPage());
            }
        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainFrame.Navigate(new ReviewEntryPage());
            }
        }

        private void ViewReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainFrame.Navigate(new ReviewListPage());
            }
        }

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new LoginPage(new DeleteCarPage()));
        }

        private void ExitImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExitImage_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as System.Windows.Controls.Image;
            if (image != null)
            {
                image.Opacity = 0.7; 
            }
        }

        private void ExitImage_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as System.Windows.Controls.Image;
            if (image != null)
            {
                image.Opacity = 1.0;
            }
        }
    }
}
