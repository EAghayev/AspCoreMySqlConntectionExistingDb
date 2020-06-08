using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechlandMysqlMigrateApi.Model;

namespace TechlandMysqlMigrateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly techlandContext _context;

        public PostController(techlandContext context)
        {
            _context = context;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(_context.WpPosts.OrderByDescending(d=>d.PostDate).Take(10).ToList());
        }
    }

}