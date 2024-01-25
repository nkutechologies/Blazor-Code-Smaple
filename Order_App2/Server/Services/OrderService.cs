using Microsoft.EntityFrameworkCore;
using Order_App2.Server.Interfaces;
using Order_App2.Server.Models;
using Order_App2.Shared.Entities;

namespace Order_App2.Server.Services
{
    public class OrderService : IOrder
	{
        readonly DatabaseContext _dbContext = new();
        public OrderService(DatabaseContext dbContext)
		{
            _dbContext = dbContext;
        }

        public List<Order> GetOrderDetails()
        {
            try
            {
                return _dbContext.Orders.ToList();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteOrder(int id)
        {
            try
            {
                var order = _dbContext.Orders
                    .Include(o => o.Windows)
                        .ThenInclude(w => w.SubElements)
                    .FirstOrDefault(o => o.OrderId == id);

                if (order != null)
                {
                    try
                    {
                        // Remove SubElements first
                        foreach (var window in order.Windows)
                        {
                            _dbContext.SubElements.RemoveRange(window.SubElements);
                        }

                        // Remove Windows and then Order
                        _dbContext.Windows.RemoveRange(order.Windows);
                        _dbContext.Orders.Remove(order);

                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }


        public Order GetOrderData(int id)
        {
            try
            {
                var order = _dbContext.Orders
                    .Include(o => o.Windows)
                        .ThenInclude(w => w.SubElements)
                    .FirstOrDefault(o => o.OrderId == id);

                if (order != null)
                {
                    return order;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                var existingOrder = _dbContext.Orders
                    .Include(o => o.Windows)
                    .ThenInclude(w => w.SubElements)
                    .FirstOrDefault(o => o.OrderId == order.OrderId);

                if (existingOrder == null)
                {


                    return;
                }

                _dbContext.Entry(existingOrder).CurrentValues.SetValues(order);

                foreach (var existingWindow in existingOrder.Windows.ToList())
                {
                    if (!order.Windows.Any(w => w.WindowId == existingWindow.WindowId))
                    {
                        _dbContext.Windows.Remove(existingWindow);
                    }
                    else
                    {
                        var updatedWindow = order.Windows.First(w => w.WindowId == existingWindow.WindowId);
                        _dbContext.Entry(existingWindow).CurrentValues.SetValues(updatedWindow);

                        foreach (var existingSubElement in existingWindow.SubElements.ToList())
                        {
                            if (!updatedWindow.SubElements.Any(se => se.SubElementId == existingSubElement.SubElementId))
                            {
                                _dbContext.SubElements.Remove(existingSubElement);
                            }
                            else
                            {
                                var updatedSubElement = updatedWindow.SubElements.First(se => se.SubElementId == existingSubElement.SubElementId);
                                _dbContext.Entry(existingSubElement).CurrentValues.SetValues(updatedSubElement);
                            }
                        }
                    }
                }

                foreach (var window in order.Windows)
                {
                    var existingWindow = existingOrder.Windows?.FirstOrDefault(w => w.WindowId == window.WindowId);

                    if (existingWindow == null)
                    {
                        existingOrder.Windows?.Add(window);
                    }
                    else
                    {
                        _dbContext.Entry(existingWindow).CurrentValues.SetValues(window);

                        foreach (var subElement in window.SubElements)
                        {
                            var existingSubElement = existingWindow.SubElements?.FirstOrDefault(s => s.SubElementId == subElement.SubElementId);

                            if (existingSubElement == null)
                            {
                                existingWindow.SubElements?.Add(subElement);
                            }
                            else
                            {
                                _dbContext.Entry(existingSubElement).CurrentValues.SetValues(subElement);
                            }
                        }
                    }
                }

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}

