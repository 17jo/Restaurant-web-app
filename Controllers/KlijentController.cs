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
    public class KlijentController : ControllerBase
    {
        public RestoranContext Context { get; set ;}
        public KlijentController(RestoranContext context)
        {
            Context=context;
        }
        
        [Route("GetKlijent/{brojTelefona}")]//GetKlijent/{brojTelefona}
        [HttpGet]
        public async Task<ActionResult> GetKlijenta(int brojTelefona)
        {

            var klijenti = Context.Klijenti
            .Where(p => p.BrojTelefona == brojTelefona);
            var klijent = await klijenti.ToListAsync();
            var dalPostojiBroj = Context.Klijenti.Where( p => p.BrojTelefona == brojTelefona).FirstOrDefault();
            if(dalPostojiBroj == null) return BadRequest("Ne postoji uneti broj telefona");
            return Ok(
                klijent.Select(p =>
                new
                { 
                    ID=p.ID,
                    BrojTelefona = p.BrojTelefona,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                }).ToList()
            );


        }


        [Route("AddKlijent/{ime}/{prezime}/{brTel}")]
        [HttpPost]
        public async Task<ActionResult> AddKlijenta(string ime, string prezime, int brTel)
        {
          

          
            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 30)
                return BadRequest("Ime nije validno");

            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 30)
                return BadRequest("Prezime nije validno");   

            try
            {
                
                   Klijent k=new Klijent{
                    Ime=ime,
                    Prezime=prezime,
                    BrojTelefona=brTel
                    };
                    Context.Klijenti.Add(k);
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno dodaj klijent");
     
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [Route("ChangeKlijent/{ime}/{prezime}/{brTel}/{brTelNovi}")]
        [HttpPut]
        public async Task<ActionResult> ChangeKlijenta(string ime, string prezime, int brTel, int brTelNovi)
        {
            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 30)
                return BadRequest("Ime nije validno");

            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 30)
                return BadRequest("Prezime nije validno");   

            try
            {
                var klijent = Context.Klijenti.Where( p => p.BrojTelefona == brTel).FirstOrDefault();
                if(klijent != null)
                {
                    klijent.Ime=ime;
                    klijent.Prezime=prezime;
                    klijent.BrojTelefona=brTelNovi;
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno promenjen klijent sa ID: "+  klijent.ID);
                }
                else
                    return BadRequest("Klijent nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("DeleteKlijent/{brojTelefona}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteKlijenta(int brojTelefona)
        {
            var klijent = Context.Klijenti.Where( p => p.BrojTelefona == brojTelefona).FirstOrDefault();
            try
            {
                if(klijent != null)
                {
                    Context.Klijenti.Remove(klijent);
                    await Context.SaveChangesAsync();
                    return Ok("Izbrisan klijent sa ID: "+ klijent.ID);

                }
                else   
                    return BadRequest("Klijent nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
