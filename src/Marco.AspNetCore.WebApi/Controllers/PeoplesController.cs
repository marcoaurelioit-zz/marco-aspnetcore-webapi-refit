using System;
using System.Threading.Tasks;
using Marco.AspNetCore.Domain.Adapters;
using Marco.AspNetCore.WebApi.BootStrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marco.AspNetCore.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class PeoplesController : ApiBaseController
    {
        private readonly IPeopleAdapter _peopleAdapter;

        public PeoplesController(IPeopleAdapter peopleAdapter)
        {
            _peopleAdapter = peopleAdapter ?? throw new ArgumentNullException(nameof(peopleAdapter));
        }

        /// <summary>
        /// Get people by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeopleByIdAsync([FromRoute]int id)
        {
            var people = await _peopleAdapter.GetByIdAsync(id);

            if (people is null)
                return NotFound();

            return Ok(people);
        }
    }
}