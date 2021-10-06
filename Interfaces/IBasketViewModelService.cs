using System.Threading.Tasks;
using Web.Pages.Basket;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    }
}
