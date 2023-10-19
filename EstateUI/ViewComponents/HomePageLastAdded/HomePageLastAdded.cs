using EstateAPI.Dtos.Estate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstateUI.ViewComponents.HomePageLastAdded
{
    public class HomePageLastAdded : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiUrl = "https://localhost:7213/api/Estate/GetAll";

        public HomePageLastAdded(IHttpClientFactory httpClientFactory)
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
                    var data = JsonConvert.DeserializeObject<ResponseDto<List<EstateListDto>>>(jsonData);
                    return View(data.Data);
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Herhangi Bir Mülk Bulunamadı";
            }
            return View(new List<EstateListDto>());
        }
    }
}
