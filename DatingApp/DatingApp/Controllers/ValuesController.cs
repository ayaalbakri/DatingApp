using DatingApp.DataContext;
using DatingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataBaseContext _context;

        public ValuesController(DataBaseContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //throw new System.Exception("Hiii");
            return Ok(_context.Values.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Value value)
        {
            await _context.Values.AddAsync(value);
            return Ok("VALUE ADDED");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
