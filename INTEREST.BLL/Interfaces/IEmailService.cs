﻿using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
