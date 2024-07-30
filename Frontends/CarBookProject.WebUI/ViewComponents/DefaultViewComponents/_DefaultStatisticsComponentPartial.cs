using CarBookProject.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBookProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory,
                                                  IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
            var token = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;

			if (token != null)
			{
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                #region statistics1
                var responseMessage = await client.GetAsync("https://localhost:7269/api/Statistics/GetCarCount");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                    ViewBag.carCount = values.CarCount;
                }
                #endregion

                #region statistics2
                var responseMessage2 = await client.GetAsync("https://localhost:7269/api/Statistics/GetLocationCount");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                    ViewBag.locationCount = values2.LocationCount;
                }
                #endregion

                #region statistics3
                var responseMessage3 = await client.GetAsync("https://localhost:7269/api/Statistics/GetBrandCount");
                if (responseMessage3.IsSuccessStatusCode)
                {
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                    ViewBag.brandCount = values3.BrandCount;
                }
                #endregion

                #region statistics4
                var responseMessage4 = await client.GetAsync("https://localhost:7269/api/Statistics/GetCarCountByFuelElectric");
                if (responseMessage4.IsSuccessStatusCode)
                {
                    var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                    var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                    ViewBag.carCountByFuelElectric = values4.CarCountByFuelElectric;
                }
                #endregion


            }

            return View();
		}
    }
}
