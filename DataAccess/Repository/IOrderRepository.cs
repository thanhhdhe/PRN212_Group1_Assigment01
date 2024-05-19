using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
		IEnumerable<Order> GetOrders();
		Order GetOrderByID(int OrderId);
		void InsertOrder(Order Order);
		void DeleteOrder(int OrderId);
		void UpdateOrder(Order Order);
		IEnumerable<Order> GetOrdersByStaffID(int id);
		IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate);

		IEnumerable<Order> GetOrdersByDateAndStaffID(DateTime startDate, DateTime endDate, int staffId);
	}
}
