using Abp.Authorization;
using SPAVUE.Authorization.Roles;
using SPAVUE.Authorization.Users;

namespace SPAVUE.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
