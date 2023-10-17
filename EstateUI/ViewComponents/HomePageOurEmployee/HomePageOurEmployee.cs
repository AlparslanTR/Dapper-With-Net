using EstateAPI.Dtos.Category;
using EstateAPI.Dtos.EmployeeRelationComment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace EstateUI.ViewComponents.HomePageOurEmployee
{
    public class HomePageOurEmployee : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiUrl = "https://localhost:7213/api/EmployeeRelationsComments/GetComments";

        public HomePageOurEmployee(IHttpClientFactory httpClientFactory)
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
                    var data = JsonConvert.DeserializeObject<ResponseDto<List<RelationCommentsListDto>>>(jsonData);
                    return View(data.Data);
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessageForName"] = "Henüz Yorum Yapan Müşteri Bulunamadı";
                TempData["ErrorMessageForDefaultComment"] = "Yorum Yok";
            }
            return View(new List<RelationCommentsListDto>());
        }
    }
}
