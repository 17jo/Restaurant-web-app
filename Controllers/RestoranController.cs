using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;

namespace restoran.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestoranController : ControllerBase
    {
        public RestoranContext Context { get; set ;}
        public RestoranController(RestoranContext context)
        {
            Context=context;
        }
        
        [Route("GetRestoran")]
        [HttpGet]
        public async Task<ActionResult> GetRestorani()
        {
            try
            {
                return Ok(await Context.Restorani.Select( p => new{ p.ID, p.ImeRestorana}).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}