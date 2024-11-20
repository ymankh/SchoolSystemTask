using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using SchoolSystemTask.services;

namespace SchoolSystemTask.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaimentApiController(PayPalService payPalService) : ControllerBase
    {
        [Authorize]
        [HttpPost("checkout")]
        public IActionResult CreatePayment()
        {
            var redirectUrl = "";
            var totalPrice = 20;
            if (string.IsNullOrEmpty(redirectUrl))
                throw new Exception("The redirect link for the paypal should be set correctly on the sitting app.");

            var payment = payPalService.CreatePayment(redirectUrl ?? " ", totalPrice, null, GetUserId());
            var approvalUrl = payment.links.FirstOrDefault(l => l.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase))?.href;

            return Ok(new { approvalUrl });
        }
        [HttpGet]
        public IActionResult GetHostUrl()
        {
            // Retrieve the full URL of the current request
            var fullUrl = HttpContext.Request.GetDisplayUrl();

            // Extract the scheme (http/https) and host (domain and port)
            var hostUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

            // Return the host URL as part of the response
            return Ok(new { HostUrl = hostUrl, FullUrl = fullUrl });
        } 
        private int GetUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
