using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DataAccess
{
    public class OrderService
    {
        public static List<Order> GetList(int? id)
        {
            var listOrder = new List<Order>();
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    if (id != null)
                    {
                        listOrder = context.Orders.Where(x => x.OrderId == id).ToList();
                    }
                    else
                    {
                        listOrder = context.Orders.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("List Order fail" + e.Message);
            }
            return listOrder;
        }
        public static Order FindOrderById(int id)
        {
            var Order = new Order();
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    Order = context.Orders.SingleOrDefault(x => x.OrderId == id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FindOrderById fail" + e.Message);
            }
            return Order;
        }
        public static void Add(Order p)
        {
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    context.Orders.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Fail " + e.Message);
            }
        }
        public static void Update(Order p)
        {
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    var existingOrder = context.Orders.SingleOrDefault(x => x.OrderId == p.OrderId);
                    if (existingOrder != null)
                    {
                        context.Entry(existingOrder).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Fail " + e.Message);
            }
        }
        public static void Delete(int p)
        {
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    var Order = context.Orders.FirstOrDefault(x => x.OrderId == p);
                    if (Order != null)
                    {
                        context.Orders.Remove(Order);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Fail " + e.Message);
            }
        }
    }
}
