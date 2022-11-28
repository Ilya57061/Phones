using Booking.BusinessLogic.Implementation;
using Booking.Model.Models;
using System.Windows;
using System.Windows.Controls;

namespace BookingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhoneService _phoneService;
        public MainWindow()
        {
            InitializeComponent();
            _phoneService = new PhoneService();
            phonesGrid.ItemsSource = _phoneService.Get();
        }
        private void UpdateGrid()
        {
            phonesGrid.ItemsSource = null;
            phonesGrid.ItemsSource = _phoneService.Get();
        }
   
  
        private void NewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow win = new AddWindow();
            win.Show();
        }
       
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
           
            if (phonesGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo)==MessageBoxResult.Yes )
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    Phone phone = phonesGrid.SelectedItems[i] as Phone;
                    if (phone != null)
                    {
                        _phoneService.Delete(phone);
                    }
                }
            }
            UpdateGrid();
           
        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _phoneService.Update(e.Row.Item as Phone);
            UpdateGrid();
        }
    }
}
