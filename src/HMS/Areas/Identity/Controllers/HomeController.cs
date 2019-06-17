using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [Authorize]
    [BreadCrumb(Title = "تشخیص هویت", UseDefaultRouteUrl = true, Order = 0)]
    public class HomeController : Controller
    {
        [BreadCrumb(Title = "اطلاعات تشخیص هویت", Order = 1)]
        public IActionResult Index() => View();
    }
}