using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IRolesService : IDisposable
    {
        List<IdentityRole> GetRoles();
        Task CreateRole(string role);
        Task DeleteRole(string id);
    }
}
