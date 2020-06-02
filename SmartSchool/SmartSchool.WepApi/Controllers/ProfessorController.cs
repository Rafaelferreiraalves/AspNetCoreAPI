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
        private readonly IRepository repo;
        public ProfessorController(IRepository repo) 
        {
            this.repo = repo;
          
        }

        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return repo.GetAllProfessores();
        }

        // GET: api/Aluno/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                Professor professor = repo.GetProfessorById(id, true);
                if (professor != null)
                    return Ok(professor);
                else
                    return NotFound("Voce se fudeu hein");
            }
            catch (Exception ex )
            {
                string messa = ex.Message;

                return BadRequest();
            }
         
        
        }
        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] Professor value)
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
        public IActionResult Put(int id, [FromBody] Professor value)
        {
            var professor = repo.GetProfessorById(id, true);

            if (id == 0 || professor == null)
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
            var professor = repo.GetProfessorById(id, true);
            if (id == 0 || professor == null)
            {
                return BadRequest();
            }

            repo.Delete(professor);
            repo.SaveChanges();
            return Ok();
        }
    }
}