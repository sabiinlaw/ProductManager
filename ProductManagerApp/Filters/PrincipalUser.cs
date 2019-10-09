using System.Security.Principal;

namespace ProductManagerApp.Filters
{
    public class PrincipalUser : IPrincipal
    {
        public PrincipalUser()
        {

        }
        public PrincipalUser(int userId, string userName, string role)
        {
            UserId = userId;
            UserName = userName;
            Role = role;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public IIdentity Identity { get; set; }
        public bool IsInRole(string role)
        {
            return role.Equals(Role, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}