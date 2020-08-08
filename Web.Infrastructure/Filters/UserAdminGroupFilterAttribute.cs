using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Models.Enums;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Filters
{
    public class UserAdminGroupFilterAttribute: TypeFilterAttribute
    {
        public UserAdminGroupFilterAttribute(RightType right):
        base(typeof(UserAdminGroupFilter))
        {
            
            this.Arguments= new object[]{right};
        }
        private class UserAdminGroupFilter : Attribute, IAsyncActionFilter
        {
            private RightType _right;
            private IGroupsDbStore _context;
            public UserAdminGroupFilter(object right,IGroupsDbStore context)
            {
                _right=(RightType)right;
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

                if(!_context.getRight(loginGroup, login).Result.Any(x=>x==_right))
                {
                    context.Result= new UnauthorizedObjectResult("no rights");
                    return;
                }
                await next();
            }
        }
    }
}