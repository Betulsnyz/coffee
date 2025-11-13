using Coffy.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace CoffyApi.Hubs
{
    public class CoffyHub : Hub 
    {
        CoffyContext context = new CoffyContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
