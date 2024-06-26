using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Repository.MyShop.Infrastructure.Repositories;

namespace Repository.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ShoppingContext context;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<LineItem> lineItemRepository;

        public UnitOfWork(ShoppingContext context)
        {
            this.context = context;
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<LineItem> LineItemRepository
        {
            get
            {
                if (lineItemRepository == null)
                {
                    lineItemRepository = new GenericRepository<LineItem>(context);
                }
                return lineItemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
