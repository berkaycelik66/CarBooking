using CarBooking.Dto.AboutDtos;
using CarBooking.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBooking.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RentACarFilterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
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
    }
}
