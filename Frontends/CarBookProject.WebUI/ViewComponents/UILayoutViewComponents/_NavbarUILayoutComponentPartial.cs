using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarBookProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public _NavbarUILayoutComponentPartial(  IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public IViewComponentResult Invoke()
		{
            var token = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;

            //var token = HttpContext.Request.Cookies["jwtToken"];
            if (token is not null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var fullNameClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "NameSurname");
                var fullName = fullNameClaim?.Value;

                ViewBag.FullName = fullName;
            }

            return View();
        }
    }
}
