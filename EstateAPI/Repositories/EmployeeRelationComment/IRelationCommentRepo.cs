using EstateAPI.Dtos.EmployeeRelationComment;

namespace EstateAPI.Repositories.EmployeeRelationComment
{
    public interface IRelationCommentRepo
    {
        Task<ResponseDto<List<RelationCommentsListDto>>> GetCommentsWithEmployee();
    }
}
