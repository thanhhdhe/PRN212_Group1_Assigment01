using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace MyStoreWPFApp
{
    /// <summary>
    /// Interaction logic for StaffDashboard.xaml
    /// </summary>
    public partial class StaffDashboard : Window
    {
		public Staff Staff { get; set; }
		public StaffDashboard(Staff Staff)
        {
            InitializeComponent();
			MainFrame.Navigate(new HomePage());
		}
		private void NavigateToHome(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new HomePage());
		}

		private void NavigateToProducts(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new ProductsPage());
		}

		private void NavigateToOrders(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new OrdersPage(Staff.StaffId));
		}

		private void LogoutButton_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}
