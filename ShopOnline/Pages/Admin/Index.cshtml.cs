using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Constants;
using Web.Extensions;
using Web.Services;
using Web.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Web.Pages.Admin
{
    [Authorize(Roles = ApplicationCore.Authorization.Constants.Roles.ADMINISTRATORS)]
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
           
        }
    }
}
