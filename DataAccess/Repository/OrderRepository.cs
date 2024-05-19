using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class OrderRepository : IOrderRepository
	{
		public void DeleteOrder(int OrderId)
		{
			OrderDAO.Instance.RemoveOrder(OrderId);
		}

		public Order GetOrderByID(int OrderId)
		{
			return OrderDAO.Instance.GetOrder(OrderId);
		}

		public IEnumerable<Order> GetOrders()
		{
			return OrderDAO.Instance.GetOrders();
		}

		public void InsertOrder(Order Order)
		{
			OrderDAO.Instance.InsertOrder(Order);
		}

		public void UpdateOrder(Order Order)
		{
			OrderDAO.Instance.UpdateOrder(Order);
		}

		public IEnumerable<Order> GetOrdersByStaffID(int id)
		{
			return OrderDAO.Instance.GetOrdersByStaffID(id);
		}

		public IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
		{
			return OrderDAO.Instance.GetOrdersByDate(startDate, endDate);
		}

		public IEnumerable<Order> GetOrdersByDateAndStaffID(DateTime startDate, DateTime endDate, int staffId)
		{
			return OrderDAO.Instance.GetOrdersByDateAndStaffID(startDate, endDate, staffId);
		}

	}
}
