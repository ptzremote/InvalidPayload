using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication3
{
    public class HomeController : Controller
    {
        private readonly IAntiforgery _antiforgery;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IAntiforgery antiforgery, ILogger<HomeController> logger)
        {
            _antiforgery = antiforgery;
            _logger = logger;
        }

        public async Task Index()
        {
            try
            {
                await _antiforgery.ValidateRequestAsync(HttpContext);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Antiforgery validation failed");
                throw;
            }
        }
    }
}
