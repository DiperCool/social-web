using System.Collections.Generic;
using AutoMapper;
using Web.Infrastructure.Pagination;
using Web.Infrastructure.validation;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Models;
using Web.Models.Interfaces.Domains;
using Web.Models.EntityModels;

namespace Web.Domain.Comments
{
    public class Comments:IComments
    {
        ICommentStore _context;
        IMapper _mapper;
        public Comments(ICommentStore context)  
        {
            _context=context;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper = new Mapper(config);
        }

        public CommentDTO changeComment(int id, ChangeCommentModel model)
        {
            return _mapper.Map<Comment, CommentDTO>(_context.changeComment(id, model.Id, model.Content, model.Login));
        }

        public CommentDTO createComment(int id, CommentModel model)
        {
            return _mapper.Map<Comment, CommentDTO>(_context.createComment(id, model));
        }

        public void deleteComment(int id, int idComment, string login)
        {
            _context.deleteComment(id, idComment,login);
        }

        public PaginationResult<LikeCommentDTO> getComments(int id, int page,string likelogin)
        {
            int size=5;
            List<LikeCommentEntity> comments= _context.getComments(id, size, page,likelogin);
            List<LikeCommentDTO> commentsDto=_mapper.Map<List<LikeCommentEntity>,List<LikeCommentDTO>>(comments);
            return new PaginationResult<LikeCommentDTO>{
                Result= commentsDto,
                isEnd=comments.Count<size,
            };
        }
    }
}