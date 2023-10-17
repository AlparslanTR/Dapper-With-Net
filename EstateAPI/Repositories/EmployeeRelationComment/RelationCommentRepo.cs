using Dapper;
using EstateAPI.Data;
using EstateAPI.Dtos.EmployeeRelationComment;
using System.Net;

namespace EstateAPI.Repositories.EmployeeRelationComment
{
    public class RelationCommentRepo : IRelationCommentRepo
    {
        private readonly AppDbContext _context;
        private const string QueryListCommentsWithEmployee =
        "Select ERC.Id, ERC.Comments, E.Name as EmployeeName from EmployeeRelationsComments as ERC inner join Employee as E on ERC.EmployeeId = E.Id";

        public RelationCommentRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<RelationCommentsListDto>>> GetCommentsWithEmployee()
        {
            using (var connection = _context.CreateConnection())
            {
                var getComment = await connection.QueryAsync<RelationCommentsListDto>(QueryListCommentsWithEmployee);
                if (getComment is null)
                {
                    return ResponseDto<List<RelationCommentsListDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                }
                return ResponseDto<List<RelationCommentsListDto>>.CreateSuccess(getComment.ToList(), "Başarılı ", HttpStatusCode.OK);
            }
        }
    }
}
