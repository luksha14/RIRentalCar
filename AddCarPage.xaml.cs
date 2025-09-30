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
    /// Interaction logic for AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        public AddCarPage()
        {
            InitializeComponent();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            string model = ModelTextBox.Text;
            int year;
            decimal pricePerDay;

            if (string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Model of the car is missing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(YearTextBox.Text, out year))
            {
                MessageBox.Show("Input of the Year is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out pricePerDay) || pricePerDay <= 0)
            {
                MessageBox.Show("Input of the prise is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var context = new RentalCarContext())
            {
                Car newCar = new Car
                {
                    Model = model,
                    Year = year,
                    PricePerDay = pricePerDay,
                    IsReserved = false
                };

                context.Cars.Add(newCar);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Car is added sucesfuly.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong with adding Car: {ex.Message}\n\n{ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            ModelTextBox.Clear();
            YearTextBox.Clear();
            PriceTextBox.Clear();
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
