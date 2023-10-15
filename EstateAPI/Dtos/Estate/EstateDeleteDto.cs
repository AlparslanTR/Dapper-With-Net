namespace EstateAPI.Dtos.Estate
{
    public record EstateDeleteDto(int id, string title, decimal price, string city, string district, int categoryId)
    {
    }
}
