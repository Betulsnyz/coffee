using Coffy.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductWithCategory();
        int TProductCount();
        int TProductCountByCategoryNameMakarna();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAvg();
        String TProductNameByMaxPrice();
        String TProductNameByMinPrice();
    }
}
