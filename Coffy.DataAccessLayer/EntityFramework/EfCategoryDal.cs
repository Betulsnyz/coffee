using Coffy.DataAccessLayer.Abstract;
using Coffy.DataAccessLayer.Concrete;
using Coffy.DataAccessLayer.Repositories;
using Coffy.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(CoffyContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new CoffyContext();
            return context.Categories.Where(x => x.Status == true).Count();

        }

        public int CategoryCount()
        {
            using var context = new CoffyContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new CoffyContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
