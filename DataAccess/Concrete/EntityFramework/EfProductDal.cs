using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Nuget
    public class EfProductDal : IProductDal
    {

        public void Add(Product entity)
        {
            // IDısposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);  // Referansı Yakala
                addedEntity.State = EntityState.Added;   // Eklenecek Nesne
                context.SaveChanges();                  // İşlemleri yap kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);    // Referansı Yakala
                deletedEntity.State = EntityState.Deleted;   // Silinecek Nesne
                context.SaveChanges();                      // İşlemleri yap kaydet.
            }
        }
        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);    // Referansı Yakala
                updatedEntity.State = EntityState.Modified;   // Güncellenecek Nesne
                context.SaveChanges();                      // İşlemleri yap kaydet.
            }
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();

            }
        }

        
    }
}
