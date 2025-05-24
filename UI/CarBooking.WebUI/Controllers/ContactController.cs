using CarBooking.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7164/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
