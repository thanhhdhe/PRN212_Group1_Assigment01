using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(int OrderDetailId)
        {
            OrderDetailDAO.Instance.RemoveOrderDetail(OrderDetailId);
        }

        public OrderDetail GetOrderDetailByID(int OrderDetailId)
        {
            return OrderDetailDAO.Instance.GetOrderDetailById(OrderDetailId);
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return OrderDetailDAO.Instance.GetOrderDetails();
        }

		public IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int id)
		{
			return OrderDetailDAO.Instance.GetOrderDetailsByOrderID(id);
		}

		public void InsertOrderDetail(OrderDetail OrderDetail)
        {
            OrderDetailDAO.Instance.AddOrderDetail(OrderDetail);
        }

        public void UpdateOrderDetail(OrderDetail OrderDetail)
        {
            OrderDetailDAO.Instance.UpdateOrderDetail(OrderDetail);
        }
    }
}
