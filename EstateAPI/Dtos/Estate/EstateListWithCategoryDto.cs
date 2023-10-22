namespace EstateAPI.Dtos.Estate
{
    public record EstateListWithCategoryDto(int id, string title, decimal price, int cityId, string categoryName)
    {
    }
}
