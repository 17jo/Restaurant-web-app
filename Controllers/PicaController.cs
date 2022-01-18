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
    public class PicaController : ControllerBase
    {
        public RestoranContext Context { get; set ;}
        public PicaController(RestoranContext context)
        {
            Context=context;
        }
        
        [Route("GetPica")]
        [HttpGet]
        public async Task<ActionResult> GetPice()
        {
            try
            {
                return Ok(await Context.Pica
                //.Where(p=> p.Restoran.ID==idRest)
                .Select( p => new{ p.ID, p.ImePica, p.Cena, p.Restoran.ImeRestorana }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

         [Route("GetPica/{idRest}")]
        [HttpGet]
        public async Task<ActionResult> GetPica(int idRest)
        {
            try
            {
            
                return Ok(await Context.Pica
                .Where(p=> p.Restoran.ID==idRest) 
                 .Select( p => new{ p.ID, p.ImePica, p.Cena,p.Restoran.ImeRestorana}).ToListAsync());
            
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}