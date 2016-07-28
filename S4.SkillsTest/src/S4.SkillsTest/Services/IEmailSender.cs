using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S4.SkillsTest.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
