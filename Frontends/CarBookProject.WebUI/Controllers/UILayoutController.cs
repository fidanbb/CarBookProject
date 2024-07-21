using CarBookProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarBookProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {

			return View();
        }
    }
}
