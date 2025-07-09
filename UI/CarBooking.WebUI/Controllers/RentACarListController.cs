using CarBooking.Dto.BrandDtos;
using CarBooking.Dto.CarDtos;
using CarBooking.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBooking.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> IndexAsync(int LocationID, string PickUpDate, string PickUpTime, string DropOffDate, string DropOffTime)
        {
            ViewBag.v1 = "Araçlar";
            ViewBag.v2 = "Uygun Araçlar";
            ViewBag.LocationID = LocationID;
            ViewBag.DropOffTime = DropOffTime;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7164/api/RentACars/{LocationID}/true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }

            return View();

        }


    }
}
