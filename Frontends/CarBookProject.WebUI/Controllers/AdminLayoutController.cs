using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CarBookProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminLayoutController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index()
        {
          
            return View();
        }

        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbarPartial()
		{
            var token = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token is not null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var fullNameClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "NameSurname");
                var fullName = fullNameClaim?.Value;

                ViewBag.FullName = fullName;
            }


            return PartialView();
        }

        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
    }
}
