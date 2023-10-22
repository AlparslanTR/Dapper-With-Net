using EstateAPI.Dtos.Category;
using EstateAPI.Dtos.City;
using EstateAPI.Dtos.EmployeeRelationComment;
using EstateAPI.Dtos.Estate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstateUI.ViewComponents.HomePagePopulationCity
{
    public class HomePagePopulationCity : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiUrl = "https://localhost:7213/api/City/GetAllWithEstateCount";

        public HomePagePopulationCity(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ResponseDto<List<CityListWithEstateCountDto>>>(jsonData);
                    return View(data.Data);
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Şehir Bilgisi Alınamadı";
                TempData["ErrorMessageListing"] = "Şehre Ait İlan 0";
            }
            return View(new List<CityListWithEstateCountDto>());
        }
    }
}
