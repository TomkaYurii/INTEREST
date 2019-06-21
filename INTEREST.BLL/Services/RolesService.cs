using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class RolesService : IRolesService
    {
        private IUnitOfWork Database { get; set; }
        public RolesService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<IdentityRole> GetRoles()
        {
            var roles = Database.RoleManager.Roles.ToList();
            return roles;
        }

        public async Task CreateRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                await Database.RoleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public async Task DeleteRole(string id)
        {
            IdentityRole role = await Database.RoleManager.FindByIdAsync(id);
            if (role != null)
            {
               await Database.RoleManager.DeleteAsync(role);
            }
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
