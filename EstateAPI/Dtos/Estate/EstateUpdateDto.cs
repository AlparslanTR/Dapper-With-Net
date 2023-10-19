namespace EstateAPI.Dtos.Estate
{
    public record EstateUpdateDto(int id, string title, decimal price, string coverImage, string city, string district, string address, string description, string type, int categoryId, int employeeId)
    {
    }
}
