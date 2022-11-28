using Booking.BusinessLogic.Implementation;
using Booking.Model.Models;
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
using System.Windows.Shapes;

namespace BookingWPF
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private PhoneService _phoneService;

        public AddWindow()
        {
            InitializeComponent();
            _phoneService = new PhoneService();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TitleTb.Text) || !String.IsNullOrEmpty(CompanyTb.Text) || !String.IsNullOrEmpty(PriceTb.Text))
                {
                    _phoneService.Create(new Phone { Title = TitleTb.Text, Company = CompanyTb.Text, Price = int.Parse(PriceTb.Text) });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
