using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrderDetailDAO
    {
		private readonly MyStoreContext _storeContext = new();
		private static OrderDetailDAO instance = null;
        private static readonly object instancelock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            var OrderDetails = new List<OrderDetail>();
            try
            {
                OrderDetails = _storeContext.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetails;
        }

		public IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int id)
		{
			var orderDetails = new List<OrderDetail>();
			try
			{
				orderDetails = _storeContext.OrderDetails
					.Where(od => od.OrderId == id)
					.Include(od => od.Product)
			.Select(od => new OrderDetail { OrderDetailId = od.OrderDetailId, Product = od.Product, Quantity = od.Quantity, UnitPrice = od.UnitPrice })
					.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return orderDetails;
		}

		public OrderDetail GetOrderDetailById(int id)
        {
            OrderDetail OrderDetail = null;
            try
            {
                OrderDetail = _storeContext.OrderDetails.SingleOrDefault(OrderDetail => OrderDetail.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetail;
        }
        public void AddOrderDetail(OrderDetail OrderDetail)
        {
            try
            {
                if (GetOrderDetailById(OrderDetail.OrderId) == null)
                {
                    _storeContext.OrderDetails.Add(OrderDetail);
                    _storeContext.SaveChanges();
                }
                else
                {
                    throw new Exception("This OrderDetail is existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail OrderDetail)
        {
            try
            {
                if (GetOrderDetailById(OrderDetail.OrderId) != null)
                {
                    _storeContext.OrderDetails.Update(OrderDetail);
                    _storeContext.SaveChanges();
                }
                else
                {
                    throw new Exception("This OrderDetail is not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveOrderDetail(int id)
        {
            try
            {
                if (GetOrderDetailById(id) != null)
                {
                    _storeContext.OrderDetails.Remove(GetOrderDetailById(id));
                    _storeContext.SaveChanges();
                }
                else
                {
                    throw new Exception("This OrderDetail is not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}