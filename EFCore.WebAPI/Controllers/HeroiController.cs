using System;
using System.Linq;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/Heroi
        [HttpGet]
        public ActionResult GetNew()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Heroi/5
        [HttpGet("{id}", Name = "GetHeroi")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST: api/Heroi
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT: api/Heroi/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if (_context.Herois.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id) != null)
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();

                    return Ok("BAZINGA!!");
                }
                return Ok("Heroi não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
