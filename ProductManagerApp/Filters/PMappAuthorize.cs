using ProductManagerApp.Util;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagerApp.Filters
{
    public class PMappAuthorize : AuthorizeAttribute
    {

        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };
        private PrincipalUser currentUser => ApContext.Initialize().CurrentUser();

        public PMappAuthorize()
        {            
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!String.IsNullOrEmpty(base.Users))
            {
                allowedUsers = base.Users.Split(new char[] { ',' });
                for (int i = 0; i < allowedUsers.Length; i++)
                {
                    allowedUsers[i] = allowedUsers[i].Trim();
                }
            }
            if (!String.IsNullOrEmpty(base.Roles))
            {
                allowedRoles = base.Roles.Split(new char[] { ',' });
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }
            }

            return httpContext.Request.IsAuthenticated &&
                 User(currentUser) && Role(currentUser);
        }

        private bool User(PrincipalUser currentUser)
        {
            if (allowedUsers.Length > 0)
            {
                return allowedUsers.Contains(currentUser.UserName);
            }
            return true;
        }

        private bool Role(PrincipalUser currentUser)
        {
            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (currentUser.IsInRole(allowedRoles[i]))
                        return true;
                }
                return false;
            }
            return true;
        }

    }
}