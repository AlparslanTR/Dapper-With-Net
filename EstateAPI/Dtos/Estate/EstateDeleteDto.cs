namespace EstateAPI.Dtos.Estate
{
    public record EstateDeleteDto(int id, string title, decimal price, int cityId, int categoryId)
    {
    }
}
