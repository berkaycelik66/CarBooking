using CarBooking.Application.Features.Mediator.Results.StatisticResults;
using CarBooking.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await GetCarCount();
            await GetLocationCount();
            await GetBrandCount();
            await GetAverageRentPriceForDaily();
            return View();
        }

        public async Task GetCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                if (value != null)
                {
                    ViewBag.CarCount = value.CarCount;
                }
            }
        }

        public async Task GetLocationCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetLocationCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultLocationCountDto>(jsonData);
                if (value != null)
                {
                    ViewBag.LocationCount = value.LocationCount;
                }
            }
        }

        public async Task GetBrandCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetBrandCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBrandCountDto>(jsonData);
                if (value != null)
                {
                    ViewBag.BrandCount = value.BrandCount;
                }
            }
        }

        public async Task GetAverageRentPriceForDaily()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetAverageRentPriceForDaily");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultAverageRentPriceForDailyDto>(jsonData);
                if (value != null)
                {
                    ViewBag.AverageRentPriceForDaily = value.AverageRentPriceForDaily.ToString("0.00") + " TL";
                }
            }
        }
    }
}
