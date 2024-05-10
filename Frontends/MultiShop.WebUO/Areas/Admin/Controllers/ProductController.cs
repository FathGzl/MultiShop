﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/products");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();          
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/products", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            return View();

        }


        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7100/api/products?id={id}");
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }


        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList();

            var clientCategory = _httpClientFactory.CreateClient();
            var responseMessageCategory = await clientCategory.GetAsync("https://localhost:7100/api/categories");
            var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
            var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
            List<SelectListItem> categoryValues = (from x in valuesCategory
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7100/api/products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7100/api/products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            return View();
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        void ProductViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";
        }
    }
}