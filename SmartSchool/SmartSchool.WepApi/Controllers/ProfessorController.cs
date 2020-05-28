using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WepApi.Data;
using SmartSchool.WepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext context;
        public ProfessorController(DataContext context) 
        {

            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return context.Professor;
        }

        // GET: api/Aluno/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Professor aluno = (from alunoSelected in context.Professor
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
            var aluno = (from alunoSelected in context.Professor
                         where alunoSelected.Nome.Contains(name)
                         select alunoSelected);
            if (aluno != null)
                return Ok(aluno);
            else
                return NotFound("Voce se fudeu hein");
        }

        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] Professor value)
        {
            try
            {
                context.Professor.Add(value);
                context.SaveChanges();
            }
            catch (Exception ex)
            {


            }
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor value)
        {
            var aluno = context.Professor.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            if (id == 0 || aluno == null)
            {
                return BadRequest();
            }
            context.Update(value);
            context.SaveChanges();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = context.Professor.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (id == 0 || aluno == null)
            {
                return BadRequest();
            }

            context.Professor.Remove(aluno);
            context.SaveChanges();
            return Ok();
        }
    }
}