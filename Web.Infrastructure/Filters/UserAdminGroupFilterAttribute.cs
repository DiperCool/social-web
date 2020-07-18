using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Models.Enums;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Filters
{
    public class UserAdminGroupAttribute : Attribute, IAsyncActionFilter
    {
        private RightType _right;
        private IGroupsDbStore _context;
        public UserAdminGroupAttribute(RightType right,IGroupsDbStore context)
        {
            right=_right;
            _context=context;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // _context= (IGroupsDbStore)context.HttpContext.RequestServices.GetService(typeof(IGroupsDbStore));
            if(!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result= new UnauthorizedObjectResult("хто я");
                return;
            }
            string login=context.HttpContext.User.Identity.Name;
            string loginGroup=context.HttpContext.Request?.Query["loginGroup"];
            if(loginGroup==null)
            {
                return;
            }

            if(await _context.getRight(loginGroup, login)<_right)
            {
                context.Result= new UnauthorizedObjectResult("no rights");
                return;
            }
            await next();
        }
    }
}