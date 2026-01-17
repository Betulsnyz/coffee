using Coffy.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductWithCategory();
        int ProductCount();
        int ProductCountByCategoryNameMakarna();
        int ProductCountByCategoryNameDrink();
        decimal ProductPriceAvg();
        String ProductNameByMaxPrice();
        String ProductNameByMinPrice();
        decimal ProductAvgPriceByMakarna();
        List<Product> GetLast9Products();
    }
}
