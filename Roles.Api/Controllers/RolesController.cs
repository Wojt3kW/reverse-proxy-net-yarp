using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Roles.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;

        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            var url = Request.GetEncodedUrl();
            _logger.LogDebug($"get roles from '{url}'");

            return Enumerable
                .Range(1, 5)
                .Select(index => new Role(index, $"Role{index}"))
                .ToList();
        }
    }
}