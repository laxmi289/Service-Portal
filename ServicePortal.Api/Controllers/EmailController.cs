using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePortal.Api.Models.Services;
using ServicePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
