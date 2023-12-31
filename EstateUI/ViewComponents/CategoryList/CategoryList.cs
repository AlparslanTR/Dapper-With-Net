﻿using EstateAPI.Dtos.Category;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EstateUI.ViewComponents.CategoryList
{
    public class CategoryList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiUrl = "https://localhost:7213/api/Category/GetAll";

        public CategoryList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ResponseDto<List<CategoryListDto>>>(jsonData);
                    return View(data.Data);
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Kategori Bulunamadı";
            }
            return View(new List<CategoryListDto>());
        }
    }
}
