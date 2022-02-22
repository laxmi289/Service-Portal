using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicePortal.Models;

namespace ServicePortal.Api.Models.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
