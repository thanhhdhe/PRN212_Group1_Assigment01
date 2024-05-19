using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
		private readonly MyStoreContext _storeContext = new();
		private static OrderDAO instance = null;
		private static readonly object instancelock = new object();
		public static OrderDAO Instance
		{
			get
			{
				lock (instancelock)
				{
					if (instance == null)
					{
						instance = new OrderDAO();
					}
					return instance;
				}
			}
		}
		
		public IEnumerable<Order> GetOrders()
		{
			var Orders = new List<Order>();
			try
			{
				Orders = _storeContext.Orders.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return Orders;
		}

		public IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
		{
			var Orders = new List<Order>();
			try
			{
				Orders = _storeContext.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return Orders;
		}

		public IEnumerable<Order> GetOrdersByDateAndStaffID(DateTime startDate, DateTime endDate, int staffId)
		{
			var Orders = new List<Order>();
			try
			{
				Orders = _storeContext.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate && o.StaffId == staffId).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return Orders;
		}

		public IEnumerable<Order> GetOrdersByStaffID(int id)
		{
			var Orders = new List<Order>();
			try
			{
				Orders = _storeContext.Orders.Where(o => o.StaffId == id).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return Orders;
		}
		public Order GetOrder(int id)
		{
			try
			{
				return _storeContext.Orders.FirstOrDefault(o => o.OrderId == id);
			}catch(Exception ex) {
				throw new Exception(ex.Message);
			}
			return null;
		}

		public void InsertOrder(Order order)
		{
			try
			{
				if (GetOrder(order.OrderId) == null)
				{
					_storeContext.Orders.Add(order);
					_storeContext.SaveChanges();
				}
				else
				{
					throw new Exception("This Order is existed!");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public void UpdateOrder(Order Order)
		{
			try
			{
				if (GetOrder(Order.OrderId) != null)
				{
					_storeContext.Orders.Update(Order);
					_storeContext.SaveChanges();
				}
				else
				{
					throw new Exception("This Order is not existed!");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public void RemoveOrder(int id)
		{
			try
			{
				if (GetOrder(id) != null)
				{
					_storeContext.Orders.Remove(GetOrder(id));
					_storeContext.SaveChanges();
				}
				else
				{
					throw new Exception("This Order is not existed!");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}
