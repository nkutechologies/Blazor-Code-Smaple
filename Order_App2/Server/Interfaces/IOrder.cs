using System;
using Order_App2.Shared.Entities;

namespace Order_App2.Server.Interfaces
{
	public interface IOrder
	{
        public List<Order> GetOrderDetails();

        public void AddOrder(Order order);

        public void UpdateOrder(Order order);

        public Order GetOrderData(int id);

        public void DeleteOrder(int id);
    }
}

