using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult GetList()
        {
            //LINQ COM SINTAXE DE METODO
            var heroList = _context.Herois.ToList();

            //LINQ COM SINTAXE SQL (PARA CARA HEROI IN _CONTEXT.HEROS, TRAGA HERO EM LIST())
            //var heroList = (from hero in _context.Heros
            //              select hero).ToList();
            return Ok(heroList);
        }

        // GET api/values/search/
        [HttpGet("search/{Nome}")]
        public ActionResult GetSearch(string nome)
        {
            //LINQ COM EXPRESSÃO LAMBDA
            var heroList = _context.Herois
                .Where(hero => hero.Nome.Contains(nome))
                .ToList();

            //LINQ COM SINTAXE SQL (PARA CARA HEROI IN _CONTEXT.HEROS,
            //ONDE HERO.Nome.CONTENHA(STRING BUSCADA)
            //TRAGA HERO EM LIST())
            //var heroList = (from hero in _context.Heros
            //              where hero.Nome.Contains(Nome)
            //              select hero).ToList();
            return Ok(heroList);
        }

        //UPDATE NOME DO HEROI
        // GET api/values/update/
        [HttpGet("update/{Id}/{update}")]
        public ActionResult GetUpdate(string update, int Id)
        {
            //LINQ COM EXPRESSÃO LAMBDA
            //ONDE HERO.ID FOR IGUAL AO ID, RETORNE O PRIMEIRO OU DEFAULT,
            //HERO.Nome UPDATE
            var hero = _context.Herois
                .Where(h => h.Id == Id)
                .FirstOrDefault();
            hero.Nome = update;
            _context.SaveChanges();
            return Ok(hero);
        }

        // GET api/values/NOME DO HEROI
        [HttpGet("{nomeHeroi}")]
        public ActionResult Get(string nomeHeroi)
        {
            var hero = new Heroi
            {
                Nome = nomeHeroi
            };
            _context.Herois.Add(hero);
            //PODE SE USAR "context.Add(hero);" FUNCIONA, PORÉM NAO ESPECIFICA O "HEROS"
            _context.SaveChanges();

            return Ok();
        }

        //ADD VARIOS VALORES
        // GET api/values/addRange
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" },
                new Heroi { Nome = "Thor" }
                );
            _context.SaveChanges();
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                               .Where(h => h.Id == id)
                               .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
