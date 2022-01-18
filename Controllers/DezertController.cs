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
    public class DezertController : ControllerBase
    {
        public RestoranContext Context { get; set ;}
        public DezertController(RestoranContext context)
        {
            Context=context;
        }
        
        [Route("GetDezerti")]
        [HttpGet]
        public async Task<ActionResult> GetDezert()
        {
            try
            {
                return Ok(await Context.Dezerti
               // .Where(p=> p.Restoran.ID==idRest)
                .Select( p => new{ p.ID, p.ImeDezerta, p.Cena, p.Restoran.ImeRestorana }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
         [Route("GetDezert/{idRest}")]
        [HttpGet]
        public async Task<ActionResult> GetDezert(int idRest)
        {
            try
            {
            
                return Ok(await Context.Dezerti
                .Where(p=> p.Restoran.ID==idRest) 
                 .Select( p => new{ p.ID, p.ImeDezerta, p.Cena,p.Restoran.ImeRestorana}).ToListAsync());
            
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}