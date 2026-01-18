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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(CoffyContext context) : base(context)
        {
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
            using var context=new CoffyContext();
            var value = context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            using var context = new CoffyContext();
            var value = context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
            using var context = new CoffyContext();
            return context.MenuTables.Count();
        }
    }
}
