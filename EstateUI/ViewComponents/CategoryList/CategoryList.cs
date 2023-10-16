using EstateAPI.Dtos.Category;
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
        private const string ApiUrl = "https://localhost:7213/api/Category/GetAll";

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(ApiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(content);
                        if (json is not null)
                        {
                            var categories = json["data"].ToObject<List<CategoryListDto>>();
                            return View(categories);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Kategori Bulunamadı";
            }
            return View(new List<CategoryListDto>());
        }
    }
}
