using System.Collections.Generic;
using Web.Models.AutoMapperDTO;
using Web.Models.Models;

namespace Web.Models.Interfaces
{
    public interface IComments
    {
        CommentDTO createComment(int id, CommentModel comment);
        void deleteComment(int id, int idComment, string login);
        CommentDTO changeComment(int id, ChangeCommentModel model);
        PaginationResult<CommentDTO> getComments(int id, int page);
    }
}