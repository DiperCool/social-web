using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Models.Db;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Models;

namespace Web.Infrastructure.Stores
{
    public class CommentDbStore: ICommentStore
    {
        Context _context;
        public CommentDbStore(Context context)
        {
            _context= context;
        }
        private Comment getComment(int id,int idComment, string login){
            return _context.Comments.Where(x=>x.Post.Id==id&&x.Id==idComment&&x.Author.Login==login).FirstOrDefault();
        }
        public Comment changeComment(int id, int idComment, string Content, string login)
        {
            Comment com= getComment(id, idComment,login);
            com.Content=Content;
            _context.Update(com);
            _context.SaveChanges();
            return com;

        }

        public Comment createComment(int idPost, CommentModel comment)
        {
            User user= _context.Users
                                .Where(x=>x.Login==comment.Login)
                                .Include(x=>x.Ava)
                                .FirstOrDefault();
            Post post = _context.Posts.FirstOrDefault(x=>x.Id==idPost);
            Comment com= new Comment(){To= comment.To, Content=comment.Content, Author=user, Post=post };
            post.Comments.Add(com);
            _context.Posts.Update(post);
            _context.SaveChanges();
            return com;
            

        }

        public void deleteComment(int id, int idComment, string login)
        {
            Comment com= getComment(id, idComment,login);
            if(com==null) return;
            _context.Remove(com);
            _context.SaveChanges();
        }

        public List<Comment> getComments(int id, int size, int page)
        {
            List<Comment> Comments=_context.Comments
                .AsNoTracking()
                .Where(x=>x.Post.Id==id)
                .Skip((page - 1) * size)
                .Take(size)
                .Include(x=>x.Author)
                    .ThenInclude(x=>x.Ava)
                .ToList();
            return Comments;
        }
        public int amoutComments(int id){
            return _context.Comments.Where(x=>x.Post.Id==id).Count();
        }
    }
}