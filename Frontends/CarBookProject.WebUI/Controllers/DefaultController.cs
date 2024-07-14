using CarBookProject.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7269/api/Locations");

           
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> values2=(from x in values
                                          select new SelectListItem
                                          {
                                              Text=x.Name,
                                              Value=x.LocationID.ToString()
                                          }).ToList();
                ViewBag.v=values2;
                return View();
          
        }

        [HttpPost]
        public async Task<IActionResult> Index(string book_pick_date,string book_off_date,string time_pick,string time_off,string locationID)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationid"] = locationID;

            return RedirectToAction("Index", "RentACarList");
        }
    }
}
