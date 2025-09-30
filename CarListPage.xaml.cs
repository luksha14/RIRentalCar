using RIRentalCar.Data;
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
    /// Interaction logic for CarListPage.xaml
    /// </summary>
    public partial class CarListPage : Page
    {
        public CarListPage()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            using (var context = new RentalCarContext())
            {
                var cars = context.Cars.ToList();
                CarsItemsControl.ItemsSource = cars;
            }
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainFrame.Navigate(new MainMenu());
            }
        }
    }
}
