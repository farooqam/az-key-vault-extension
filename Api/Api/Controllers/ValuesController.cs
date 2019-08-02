using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptionsSnapshot<ValuesControllerOptionsA> optionsAccessorA;
        private readonly IOptionsSnapshot<ValuesControllerOptionsB> optionsAccessorB;

        public ValuesController(
            IOptionsSnapshot<ValuesControllerOptionsA> optionsAccessorA,
            IOptionsSnapshot<ValuesControllerOptionsB> optionsAccessorB)
        {
            this.optionsAccessorA = optionsAccessorA;
            this.optionsAccessorB = optionsAccessorB;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { GroupA = this.optionsAccessorA.Value.SettingsGroup, GroupB = this.optionsAccessorB.Value.SettingsGroup });
        }
    }
}
