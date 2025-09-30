using RIRentalCar.Data;
using RIRentalCar.Models;
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
    /// Interaction logic for DeleteCarPage.xaml
    /// </summary>
    public partial class DeleteCarPage : Page
    {
        public DeleteCarPage()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            using (var context = new RentalCarContext())
            {
                CarListBox.ItemsSource = context.Cars.ToList();
            }
        }

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = (Car)((Button)sender).DataContext;

            using (var context = new RentalCarContext())
            {
                context.Cars.Remove(selectedCar);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Car is deleted sucesfuly.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCars(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong: {ex.Message}\n\n{ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BackToMainPageButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new MainMenu());
        }
    }
}
