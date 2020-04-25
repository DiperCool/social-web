using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Domain.Comments;
using Web.Infrastructure.validation;
using Web.Models.Interfaces;
using Web.Models.Models;

namespace Web.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        IComments _context;
        public CommentController(IComments context){
            _context=context;
        }
        [HttpPost("/comments/create")]
        public IActionResult addComent([FromBody] CommentModel model, int id ){
            model.Login=User.Identity.Name;
            if(!ModelStateV.IsValid<CommentModel>(model)){
                return BadRequest(ModelStateV.ErrorMessages);
            }
            return Ok(_context.createComment(id, model));
        }
        [HttpGet("/comments/get")]
        [AllowAnonymous]
        public IActionResult getComments(int id, int page){
            return Ok(_context.getComments(id, page));
        }
        [HttpPost("/comments/changeComment")]
        public IActionResult changeComment([FromBody] ChangeCommentModel model, int id ){
            model.Login=User.Identity.Name;
            if(!ModelStateV.IsValid<ChangeCommentModel>(model)){
                return BadRequest(ModelStateV.ErrorMessages);
            }
            return Ok(_context.changeComment(id, model));
        }
        [HttpPost("/comments/deleteComment")]
        public IActionResult deleteComment(int id, int idComment ){
            _context.deleteComment(id, idComment,User.Identity.Name);
            return NoContent();
        }
    }

}