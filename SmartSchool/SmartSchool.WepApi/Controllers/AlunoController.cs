using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WepApi.Data;
using SmartSchool.WepApi.Models;

namespace SmartSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IRepository repo;
        public AlunoController(DataContext context, IRepository repo)
        {
            this.context = context;
            this.repo = repo;
        }
        // GET: api/Aluno
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return context.Alunos.ToList();
        }

        // GET: api/Aluno/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Aluno aluno = (from alunoSelected in context.Alunos
                           where alunoSelected.Id == id
                           select alunoSelected).FirstOrDefault();
            if (aluno != null)
                return Ok(aluno);
            else
                return NotFound("Voce se fudeu hein");
        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var aluno = (from alunoSelected in context.Alunos
                         where alunoSelected.Nome.Contains(name)
                         select alunoSelected);
            if (aluno != null)
                return Ok(aluno);
            else
                return NotFound("Voce se fudeu hein");
        }

        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] Aluno value)
        {
            try
            {

                repo.Add(value);
                repo.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno value)
        {
            var aluno = context.Alunos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            if (id == 0 || aluno == null)
            {
                return BadRequest();
            }

            repo.Update(value);
            repo.SaveChanges();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = context.Alunos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (id == 0 || aluno == null)
            {
                return BadRequest();
            }

            repo.Delete(aluno);
            repo.SaveChanges();
            return Ok();
        }
    }
}
