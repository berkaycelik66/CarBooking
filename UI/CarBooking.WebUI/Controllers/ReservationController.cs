using CarBooking.Dto.CarDtos;
using CarBooking.Dto.CarPricingDtos;
using CarBooking.Dto.LocationDtos;
using CarBooking.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBooking.WebUI.Controllers
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
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Rezervasyon Formu";
            ViewBag.v3 = id;
            await GetCarById(id);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                if (values != null)
                {
                    List<SelectListItem> locationList = values.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.LocationID.ToString()
                    }).ToList();
                    ViewBag.LocationValues = locationList;
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7164/api/Reservations/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

        [NonAction]
        public async Task GetCarById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7164/api/Cars/GetCarByIdWithBrand/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarByIdWithBrandDto>(jsonData);
                if (values != null)
                {
                    ViewBag.CarName = values.BrandName + " - " + values.Model;
                    ViewBag.CarImage = values.CoverImageUrl;
                }
            }
        }
    }
}
