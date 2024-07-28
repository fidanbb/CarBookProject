using CarBookProject.Dtos.CarFeatureDtos;
using CarBookProject.Dtos.CarPricingDtos;
using CarBookProject.Dtos.PricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> CreateRangeCarPricing(int id)
        {
            ViewBag.CarId = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7269/api/Pricings");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);

                CreateCarPricingRangeDto model = new CreateCarPricingRangeDto
                {
                    CarID = id,
                    PricingDetails = values.Select(v => new PricingDetailDto
                    {
                        PricingID = v.PricingID,
                        Name = v.Name
                    }).ToList()
                };

                return View(model);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRangeCarPricing(CreateCarPricingRangeDto createCarPricingRangeDto)
        {
            List<CreateCarPricingDto> model=new List<CreateCarPricingDto>();

            foreach (var item in createCarPricingRangeDto.PricingDetails)
            {
                CreateCarPricingDto dto = new();
                dto.CarID=createCarPricingRangeDto.CarID;
                dto.PricingID = item.PricingID; 
                dto.Amount = item.Amount;
                model.Add(dto);
            }

            CreateCarPricingListDto prices = new()
            {
                CarPricingRanges = model
            };
               
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(prices);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7269/api/CarPricings", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });

            }

            return View(createCarPricingRangeDto);

        }
    }
}
