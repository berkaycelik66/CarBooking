using CarBooking.Dto.AboutDtos;
using CarBooking.Dto.BannerDtos;
using CarBooking.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/CarFeatures/GetCarFeaturesByCarId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {

            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.IsPresent)
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.PatchAsync("https://localhost:7164/api/CarFeatures/ChangeCarFeaturePresentToTrue/" + item.CarFeatureID, null);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.PatchAsync($"https://localhost:7164/api/CarFeatures/ChangeCarFeaturePresentToFalse/" + item.CarFeatureID, null);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
    }
}
