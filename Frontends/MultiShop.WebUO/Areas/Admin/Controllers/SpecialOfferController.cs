using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewbagList();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/specialoffers");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]

        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/specialoffers", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            return View();
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7100/api/specialoffers?id={id}");
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewbagList();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7100/api/specialoffers/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7100/api/specialoffers", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            return View();
        }


        void SpecialOfferViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
        }

    }
}
