using System.Collections.Generic;
using Web.Models.Entity;
using Web.Models.Models;

namespace Web.Models.Interfaces
{
    public interface ICommentStore
    {
        int amoutComments(int id);
        Comment createComment(int id, CommentModel comment);
        void deleteComment(int id, int idComment);
        Comment changeComment(int id, int idComment, string Content);
        List<Comment> getComments(int id, int size, int page);
    }
}