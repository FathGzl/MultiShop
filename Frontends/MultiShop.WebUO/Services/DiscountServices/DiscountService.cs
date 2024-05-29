﻿using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string code)
        { 
            var responseMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCodeAsync?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRateAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/GetDiscountCouponCountRateAsync?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;          
        }
    }
}
