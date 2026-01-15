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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(CoffyContext context) : base(context)
        {
        }
    }
}
