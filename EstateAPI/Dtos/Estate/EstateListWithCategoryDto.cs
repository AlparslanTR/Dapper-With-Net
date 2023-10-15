namespace EstateAPI.Dtos.Estate
{
    public record EstateListWithCategoryDto(int id, string title, decimal price, string city, string district, string categoryName)
    {
    }
}
