using CarBookProject.Dtos.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Packets";
            ViewBag.v2 = "Car Price Packages";

            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7269/api/CarPricings/GetCarPricingWithTimePeriodList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithTimePeriodsDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
