using Basket.API.Models;

namespace Basket.API.Repository.Getable.Basket
{
    public interface IGetableService
    {
        Task<ShoppingCart> GetShoppingCartAsync();
    }
}
