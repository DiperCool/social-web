using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Interfaces.Domains;

namespace Web.Api.Controllers
{
    [Authorize]
    public class SubscribeController : ControllerBase
    {
        private ISubscribers _context;

        public SubscribeController(ISubscribers context)
        {
            _context = context;
        }

        [HttpPost("user/subscribe")]
        public IActionResult Subscribe(string login)
        {
            _context.SubscribeToUser(login, HttpContext.User.Identity.Name);
            return NoContent();
        }

        [HttpPost("user/unSubscribe")]
        public IActionResult UnSubscribe(string login)
        {
            _context.UnSubscribeUser(login,HttpContext.User.Identity.Name);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("/user/getSubscribers")]
        public IActionResult getSubscribers(int page, string login)
        {
            return Ok(_context.GetSubscribers(login, page));
        }
        [AllowAnonymous]
        [HttpGet("/user/getSubscribed")]
        public IActionResult getSubscribed(int page, string login)
        {
            return Ok(_context.GetSubscribed(login, page));
        }
        [AllowAnonymous]
        [HttpGet("/user/isSubscribed")]
        public IActionResult UserIsSubscribed(string to, string who)
        {
            return Ok(_context.UserIsSubscribed(to, who));
        }
    }
}