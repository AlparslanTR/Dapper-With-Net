namespace EstateAPI.Dtos.Estate
{
    public record EstateListDto(int id,string title, decimal price, int cityId, string type, int categoryId)
    {
    }
}
