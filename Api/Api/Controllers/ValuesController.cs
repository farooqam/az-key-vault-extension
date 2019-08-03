using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptionsSnapshot<StorageOptions> _storageOptionsAccessor;
        private readonly IOptionsSnapshot<DatabaseOptions> _databaseOptionsAccessor;

        public ValuesController(
            IOptionsSnapshot<StorageOptions> storageOptionsAccessor,
            IOptionsSnapshot<DatabaseOptions> databaseOptionsAccessor)
        {
            _storageOptionsAccessor = storageOptionsAccessor;
            _databaseOptionsAccessor = databaseOptionsAccessor;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { StorageOptions = _storageOptionsAccessor.Value, DatabaseOptions = _databaseOptionsAccessor.Value });
        }
    }
}
