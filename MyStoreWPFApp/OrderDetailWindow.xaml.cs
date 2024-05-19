using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
		public IEnumerable<OrderDetail> OrderDetails { get; set; }

		public OrderDetailWindow(IEnumerable<OrderDetail> orderDetails)
		{
			InitializeComponent();
			OrderDetails = orderDetails ?? new List<OrderDetail>();
			OrderDetailsDataGrid.ItemsSource = OrderDetails;
		}
	}
}
