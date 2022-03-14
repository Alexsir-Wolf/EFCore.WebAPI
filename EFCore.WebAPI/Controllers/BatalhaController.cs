using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Batalha
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalha = await _repo.GetAllBatalhas(true);
                return Ok(batalha);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Batalha/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalhas = await _repo.GetBatalhaById(id, true);
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/Batalha
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Bazinga!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou!");

        }

        // PUT: api/Batalha
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangesAsync())
                        return Ok("Bazinga!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");

            }
            return Ok("Não deletado");
        }



        // DELETE: api/batalha/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);
                    if (await _repo.SaveChangesAsync())
                        return Ok("Bazinga!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");

            }
            return Ok("Não deletado");
        }
    }
}
