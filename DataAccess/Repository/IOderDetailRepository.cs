using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
		IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int id);
		OrderDetail GetOrderDetailByID(int OrderDetailId);
        void InsertOrderDetail(OrderDetail OrderDetail);
        void DeleteOrderDetail(int OrderDetailId);
        void UpdateOrderDetail(OrderDetail OrderDetail);
    }
}
