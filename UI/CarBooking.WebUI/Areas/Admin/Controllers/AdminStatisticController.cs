using CarBooking.Application.Features.Mediator.Results.StatisticResults;
using CarBooking.Dto.AuthorDtos;
using CarBooking.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            await GetCarCount();
            await GetLocationCount();
            await GetAuthorCount();
            await GetBlogCount();
            await GetBrandCount();
            await GetCarCountByTransmissionIsAuto();
            await GetCarCountByFuelElectric();
            await GetBrandNameByMaxCar();
            await GetAverageRentPriceForDaily();
            await GetAverageRentPriceForWeekly();
            await GetAverageRentPriceForMonthly();
            await GetBlogTitleByMaxBlogComment();

            return View();
        }

        [NonAction]
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

        [NonAction]
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

        [NonAction]
        public async Task GetAuthorCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetAuthorCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultAuthorCountDto>(jsonData);
                if (value != null)
                {
                    ViewBag.AuthorCount = value.AuthorCount;
                }
            }
        }

        [NonAction]
        public async Task GetBlogCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetBlogCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBlogCountDto>(jsonData);
                if (value != null)
                {
                    ViewBag.BlogCount = value.BlogCount;
                }
            }
        }

        [NonAction]
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

        [NonAction]
        public async Task GetCarCountByTransmissionIsAuto()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultCarCountByTransmissionIsAutoDto>(jsonData);
                if (value != null)
                {
                    ViewBag.CarCountByTransmissionIsAuto = value.CarCountByTransmissionIsAuto;
                }
            }
        }

        [NonAction]
        public async Task GetCarCountByFuelElectric()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultCarCountByFuelElectricDto>(jsonData);
                if (value != null)
                {
                    ViewBag.CarCountByFuelElectric = value.CarCountByFuelElectric;
                }
            }
        }

        [NonAction]
        public async Task GetBrandNameByMaxCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBrandNameByMaxCarDto>(jsonData);
                if (value != null)
                {
                    ViewBag.BrandNameByMaxCar = value.BrandNameByMaxCar;
                }
            }
        }

        [NonAction]
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

        [NonAction]
        public async Task GetAverageRentPriceForWeekly()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetAverageRentPriceForWeekly");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultAverageRentPriceForWeeklyDto>(jsonData);
                if (value != null)
                {
                    ViewBag.AverageRentPriceForWeekly = value.AverageRentPriceForWeekly.ToString("0.00") + " TL";
                }
            }
        }

        [NonAction]
        public async Task GetAverageRentPriceForMonthly()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetAverageRentPriceForMonthly");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultAverageRentPriceForMonthlyDto>(jsonData);
                if (value != null)
                {
                    ViewBag.AverageRentPriceForMonthly = value.AverageRentPriceForMonthly.ToString("0.00") + " TL";
                }
            }
        }

        [NonAction]
        public async Task GetBlogTitleByMaxBlogComment()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBlogTitleByMaxBlogCommentDto>(jsonData);
                if (value != null)
                {
                    ViewBag.BlogTitleByMaxBlogComment = value.BlogTitleByMaxBlogComment;
                }
            }
        }
    }
}
