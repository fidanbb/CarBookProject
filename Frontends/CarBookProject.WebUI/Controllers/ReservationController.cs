using CarBookProject.Dtos.LocationDtos;
using CarBookProject.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Car Rent";
            ViewBag.v2 = "Car Reservation Form";
            ViewBag.v3 = id;

            var client =  _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7269/api/Locations");

            var jsonData=await responseMessage.Content.ReadAsStringAsync();

            var values=JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> locations = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.LocationID.ToString()
                                            }).ToList();
            ViewBag.Locations = locations;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7269/api/Reservations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
