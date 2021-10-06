using Web.ViewModels;
using System.Threading.Tasks;

namespace Web.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        Task UpdateCatalogItem(CatalogItemViewModel viewModel);
    }
}
