using System.ComponentModel.DataAnnotations;

namespace EstateAPI.Dtos.Category
{
    public record CategoryListDto(int id, string name, bool status)
    {
    }
}
