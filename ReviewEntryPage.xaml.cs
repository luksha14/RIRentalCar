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
    /// Interaction logic for ReviewEntryPage.xaml
    /// </summary>
    public partial class ReviewEntryPage : Page
    {
        public ReviewEntryPage()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            NameTextBox.Clear();
            RatingComboBox.SelectedItem = null;
            CommentTextBox.Clear();
        }

        private void SaveReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Enter the name first.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedItem = RatingComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null || string.IsNullOrWhiteSpace(selectedItem.Content?.ToString()) ||
                !int.TryParse(selectedItem.Content.ToString(), out int rating) || rating < 1 || rating > 5)
            {
                MessageBox.Show("Plese select one rate between 1 i 5.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new RentalCarContext())
            {
                var review = new Review
                {
                    Name = NameTextBox.Text,
                    Rating = rating, 
                    Comment = CommentTextBox.Text
                };

                context.Reviews.Add(review);
                context.SaveChanges();
            }

            MessageBox.Show("Thank You for your Review!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            ClearForm();
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                var mainFrame = parentWindow.MainFrame;
                if (mainFrame != null)
                {
                    mainFrame.Navigate(new MainMenu());
                }
                else
                {
                    MessageBox.Show("MainFrame is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("MainWindow is not working.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
