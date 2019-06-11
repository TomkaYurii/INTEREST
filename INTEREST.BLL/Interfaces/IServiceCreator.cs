using INTERESTS.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(DbContextOptions<AppDBContext> options);
    }
}
