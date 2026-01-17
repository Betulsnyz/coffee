using Coffy.DataAccessLayer.Abstract;
using Coffy.DataAccessLayer.Concrete;
using Coffy.DataAccessLayer.Repositories;
using Coffy.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(CoffyContext context) : base(context)
        {
        }

        public List<Product> GetProductWithCategory()
        {
            var context = new CoffyContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new CoffyContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new CoffyContext();
            return context.Products.Where(x => x.CategoryID ==(context.Categories.Where(y => y.CategoryName=="Kahveler").Select(z=>z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameMakarna()
        {
            using var context = new CoffyContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Makarna").Select(z => z.CategoryID).FirstOrDefault())).Count();

        }

        public string ProductNameByMaxPrice()
        {
            using var context = new CoffyContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new CoffyContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();

        }

        public decimal ProductPriceAvg()
        {
            using var context = new CoffyContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByMakarna()
        {
            using var context = new CoffyContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Makarna").Select(z => z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
        }

        public List<Product> GetLast9Products()
        {
            using var context = new CoffyContext();
            var values = context.Products.Take(9).ToList();
            return values;
        }
    }
}
