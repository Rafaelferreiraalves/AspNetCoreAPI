using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WepApi.Data;
using SmartSchool.WepApi.Dtos;
using SmartSchool.WepApi.Models;

namespace SmartSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository repo;
        private readonly IMapper imapper;
        public AlunoController(IRepository repo, IMapper imapper)
        {
            this.repo = repo;
            this.imapper = imapper;
        }
        // GET: api/Aluno
        [HttpGet]
        public IEnumerable<AlunoDto> Get()
        {
            var alunos = repo.GetAllAlunos(true);
            var alunosRetorno =imapper.Map<IEnumerable<AlunoDto>>(alunos);
            return alunosRetorno;
        }

        // GET: api/Aluno/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Aluno aluno = repo.GetAlunoById(id);
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

            repo.Update(value);
            repo.SaveChanges();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = repo.GetAlunoById(id);
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
