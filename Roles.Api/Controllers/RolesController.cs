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
            return Enumerable
                .Range(1, 5)
                .Select(index => new Role(index, $"Role{index}"))
                .ToList();
        }
    }
}