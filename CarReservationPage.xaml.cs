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
    /// Interaction logic for CarReservationPage.xaml
    /// </summary>

     public partial class CarReservationPage : UserControl
    {
        private Car _selectedCar;
        private decimal _pricePerDay;

        public CarReservationPage()
        {
            InitializeComponent();
            LoadCars();

            DateTime today = DateTime.Today;
            StartDatePicker.DisplayDateStart = today;
            EndDatePicker.DisplayDateStart = today.AddDays(1);
        }

        private void LoadCars()
        {
            using (var context = new RentalCarContext())
            {
                var availableCars = context.Cars.ToList();
                CarListBox.ItemsSource = availableCars;
            }
        }

        private void CarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarListBox.SelectedItem is Car selectedCar)
            {
                LoadReservedDates(selectedCar.Id);

                StartDatePicker.IsEnabled = true;
                EndDatePicker.IsEnabled = true;
                UpdateTotalPrice();
            }
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartDatePicker.SelectedDate.HasValue)
            {
                EndDatePicker.DisplayDateStart = StartDatePicker.SelectedDate.Value.AddDays(1);
            }
            UpdateTotalPrice();
        }

        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (StartDatePicker.SelectedDate.HasValue && EndDatePicker.SelectedDate.HasValue && CarListBox.SelectedItem is Car selectedCar)
            {
                int totalDays = (EndDatePicker.SelectedDate.Value - StartDatePicker.SelectedDate.Value).Days;
                decimal totalPrice = totalDays * selectedCar.PricePerDay;
                TotalPriceTextBlock.Text = $"Total price: {totalPrice:C}";
            }
            else
            {
                TotalPriceTextBlock.Text = "Total price: N/A";
            }
        }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarListBox.SelectedItem is Car selectedCar && StartDatePicker.SelectedDate.HasValue && EndDatePicker.SelectedDate.HasValue)
            {
                using (var context = new RentalCarContext())
                {
                    var existingReservation = context.Reservations
                        .FirstOrDefault(r => r.CarId == selectedCar.Id &&
                                             ((StartDatePicker.SelectedDate >= r.StartDate && StartDatePicker.SelectedDate <= r.EndDate) ||
                                              (EndDatePicker.SelectedDate >= r.StartDate && EndDatePicker.SelectedDate <= r.EndDate)));

                    if (existingReservation != null)
                    {
                        MessageBox.Show("Car is allready resered for picked dates.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Dodavanje rezervacije u bazu podataka
                    var reservation = new Reservation
                    {
                        CarId = selectedCar.Id,
                        StartDate = StartDatePicker.SelectedDate.Value,
                        EndDate = EndDatePicker.SelectedDate.Value,
                        TotalPrice = (EndDatePicker.SelectedDate.Value - StartDatePicker.SelectedDate.Value).Days * selectedCar.PricePerDay
                    };
                    context.Reservations.Add(reservation);
                    context.SaveChanges();

                    MessageBox.Show("Car is resered sucesfuly.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                    StartDatePicker.SelectedDate = null;
                    EndDatePicker.SelectedDate = null;
                    StartDatePicker.IsEnabled = false;
                    EndDatePicker.IsEnabled = false;
                    TotalPriceTextBlock.Text = "Total price: N/A";

                }
            }
            else
            {
                MessageBox.Show("Please select the car and dates.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private List<DateTime> _reservedDates = new List<DateTime>();

        private void LoadReservedDates(int carId)
        {
            using (var context = new RentalCarContext())
            {
                var reservations = context.Reservations
                                          .Where(r => r.CarId == carId)
                                          .ToList();

                _reservedDates.Clear();
                foreach (var reservation in reservations)
                {
                    for (DateTime date = reservation.StartDate; date <= reservation.EndDate; date = date.AddDays(1))
                    {
                        _reservedDates.Add(date);
                    }
                }

                DisableReservedDates();
            }
        }

        private void DisableReservedDates()
        {
            StartDatePicker.BlackoutDates.Clear();
            EndDatePicker.BlackoutDates.Clear();

            foreach (var reservedDate in _reservedDates)
            {
                StartDatePicker.BlackoutDates.Add(new CalendarDateRange(reservedDate));
                EndDatePicker.BlackoutDates.Add(new CalendarDateRange(reservedDate));
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
