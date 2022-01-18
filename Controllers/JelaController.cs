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
    public class JelaController : ControllerBase
    {
        public RestoranContext Context { get; set ;}
        public JelaController(RestoranContext context)
        {
            Context=context;
        }
        
        [Route("GetJelo")]
        [HttpGet]
        public async Task<ActionResult> GetJela()
        {
            try
            {
            
                return Ok(await Context.Jela
                //.Where(p=> p.Restoran.ID==idRest) 
                 .Select( p => new{ p.ID, p.ImeJela, p.Cena,p.Restoran.ImeRestorana}).ToListAsync());
            
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("GetJelo/{idRest}")]
        [HttpGet]
        public async Task<ActionResult> GetJela(int idRest)
        {
            try
            {
            
                return Ok(await Context.Jela
                .Where(p=> p.Restoran.ID==idRest) 
                 .Select( p => new{ p.ID, p.ImeJela, p.Cena,p.Restoran.ImeRestorana}).ToListAsync());
            
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}