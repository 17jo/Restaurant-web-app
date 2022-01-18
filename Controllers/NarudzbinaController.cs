using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NarudzbinaController : ControllerBase
    {
        public RestoranContext Context { get; set ;}
        public NarudzbinaController(RestoranContext context)
        {
            Context=context;
        }
        
        [Route("GetNarudzbinu/{brojTelefona}")]
        [HttpGet]
        public async Task<ActionResult> GetNarudzbinu(int brojTelefona)
        {   
            var i = Context.Narudzbine
            .Include(p => p.Pica)
            .Include(p => p.Jela)
            .Include(p => p.Dezert)
            .Include(p => p.Klijent)
            .Where(p => p.Klijent.BrojTelefona == brojTelefona);
            
            var dalJeDobarBroj = Context.Klijenti.Where( p => p.BrojTelefona == brojTelefona).FirstOrDefault();
            if(dalJeDobarBroj==null) return BadRequest("Ne postojeci broj telefona");
            
            try
            {
                return Ok( await i.Select( p =>
                    new
                    {
                        Ime = p.Klijent.Ime,
                        Prezime = p.Klijent.Prezime,
                        Pice = p.Pica.ImePica,
                        Jela = p.Jela.ImeJela,
                        Dezert = p.Dezert.ImeDezerta,
                        
                    }).ToListAsync()
                );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("Narudzbina/{jelo}/{dezert}/{pice}/{brojTelefona}/{idRest}")]
        [HttpPost]
        public async Task<ActionResult> Narudzbina(int jelo, int dezert, int pice, int brojTelefona, int idRest)
        {
            
          
            var dalPostojiKlijent = Context.Klijenti.Where(p=> p.BrojTelefona == brojTelefona).FirstOrDefault();
           
            if(dalPostojiKlijent==null) return BadRequest("Ne postoji klijent sa unetim brojem");
          

            try
            {
                var klij = await Context.Klijenti.Where(p => p.BrojTelefona == brojTelefona).FirstOrDefaultAsync();
                var dez = await Context.Dezerti.Where(p => p.ID == dezert).FirstOrDefaultAsync();
                var hrana = await Context.Jela.Where(p => p.ID == jelo).FirstOrDefaultAsync();
                var napitak = await Context.Pica.Where(p => p.ID == pice).FirstOrDefaultAsync();
                var rest = await Context.Restorani.Where(p=>p.ID==idRest).FirstOrDefaultAsync();
                Narudzbina i =new Narudzbina
                {
                    Klijent = klij,
                    Dezert = dez,
                    Jela = hrana,
                    Pica = napitak,
                    Restoran = rest
                };

                Context.Narudzbine.Update(i);
                await Context.SaveChangesAsync();

                var podaciOIznajmljivanju = await Context.Narudzbine
                        .Include(p => p.Klijent)
                        .Include(p => p.Jela)
                        .Include(p => p.Dezert)
                        .Include(p => p.Pica)
                        .Where(p => p.Klijent.BrojTelefona == brojTelefona)
                        .Select(p =>
                        new
                        {
                            Klijenti = p.Klijent.BrojTelefona,
                            Jelo = p.Jela.ImeJela,
                            Dezert = p.Dezert.ImeDezerta,
                            Pice = p.Pica.ImePica
                        }).ToListAsync();
                return Ok(podaciOIznajmljivanju);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
