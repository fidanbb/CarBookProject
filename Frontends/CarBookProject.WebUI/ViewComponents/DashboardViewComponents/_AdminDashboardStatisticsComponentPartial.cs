﻿using CarBookProject.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBookProject.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {

                Random random = new Random();
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                #region İstatistik1
                var responseMessage = await client.GetAsync("https://localhost:7269/api/Statistics/GetCarCount");
                if (responseMessage.IsSuccessStatusCode)
                {
                    int v1 = random.Next(0, 101);
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                    ViewBag.v = values.CarCount;
                    ViewBag.v1 = v1;
                }
                #endregion

                #region İstatistik2
                var responseMessage2 = await client.GetAsync("https://localhost:7269/api/Statistics/GetLocationCount");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    int locationCountRandom = random.Next(0, 101);
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                    ViewBag.locationCount = values2.LocationCount;
                    ViewBag.locationCountRandom = locationCountRandom;
                }
                #endregion

                #region İstatistik3
                var responseMessage3 = await client.GetAsync("https://localhost:7269/api/Statistics/GetBrandCount");
                if (responseMessage3.IsSuccessStatusCode)
                {
                    int brandCountRandom = random.Next(0, 101);
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                    ViewBag.brandCount = values3.BrandCount;
                    ViewBag.brandCountRandom = brandCountRandom;
                }
                #endregion

                #region İstatistik4
                var responseMessage4 = await client.GetAsync("https://localhost:7269/api/Statistics/GetAvgRentPriceForDaily");
                if (responseMessage4.IsSuccessStatusCode)
                {
                    int avgRentPriceForDailyRandom = random.Next(0, 101);
                    var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                    var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                    ViewBag.avgRentPriceForDaily = values4.AvgPriceForDaily.ToString("0.00"); ;
                    ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
                }
                #endregion
            }



            return View();
        }
    }
}
