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
    /// Interaction logic for ReviewListPage.xaml
    /// </summary>
    public partial class ReviewListPage : UserControl
    {
        public ReviewListPage()
        {
            InitializeComponent();
            LoadReviews();
        }

        private void LoadReviews()
        {
            using (var context = new RentalCarContext())
            {
                var reviews = context.Reviews.ToList();
                ReviewListBox.ItemsSource = reviews;
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
