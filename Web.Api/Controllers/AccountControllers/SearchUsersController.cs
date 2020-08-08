using Microsoft.AspNetCore.Mvc;
using Web.Models.Interfaces.Domains;

namespace Web.Api.Controllers.AccountControllers
{
    public class SearchUsersController:ControllerBase
    {
        private ISearchUsers _context;

        public SearchUsersController(ISearchUsers context)
        {
            _context = context;
        }
        [HttpGet("/searchUsers")]
        public IActionResult SearchUsers(string contains, int page)
        {
            return Ok(_context.GetUserWithContains(contains,page));
        }
    }
}