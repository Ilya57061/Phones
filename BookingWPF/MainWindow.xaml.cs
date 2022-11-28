using Booking.BusinessLogic.Implementation;
using Booking.Model.Database;
using Booking.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
   
  
        private void newWindowButton_Click(object sender, RoutedEventArgs e)
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
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _phoneService.Update(e.Row.Item as Phone);
            UpdateGrid();
        }
    }
}
