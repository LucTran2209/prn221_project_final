using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DataAccess
{
    public interface IOrderRepository
    {
        List<Order> GetList(int? id);
        Order GetById(int id);
        void Add(Order Order);
        void Delete(int p);
        void Update(Order Order);
    }

    public class OrderRepository : IOrderRepository
    {
        public void Add(Order Order)
        {
           OrderService.Add(Order);
        }

        public void Delete(int p)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetList(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order Order)
        {
            throw new NotImplementedException();
        }
    }
}
