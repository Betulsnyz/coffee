using Coffy.BusinessLayer.Abstract;
using Coffy.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace CoffyApi.Hubs
{
    public class CoffyHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CoffyHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameMakarna();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameMakarna", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

        }

    }
}
