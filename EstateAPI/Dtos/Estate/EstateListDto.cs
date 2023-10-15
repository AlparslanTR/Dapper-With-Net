namespace EstateAPI.Dtos.Estate
{
    public record EstateListDto(int id,string title, decimal price, string city, string district,int categoryId)
    {
    }
}
