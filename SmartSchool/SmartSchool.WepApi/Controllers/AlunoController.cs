using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WepApi.Models;

namespace SmartSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){ Id =1,Nome="Marcos",Telefone="12355"},
            new Aluno(){ Id =2,Nome="Marta",Telefone="4567"},
            new Aluno(){ Id =3,Nome="Lucas",Telefone="55434"},
                   new Aluno(){ Id =4,Nome="Laura",Telefone="67899"},
        };

        // GET: api/Aluno
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return Alunos;
        }

        // GET: api/Aluno/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Aluno aluno = (from alunoSelected in Alunos
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
            Aluno aluno = (from alunoSelected in Alunos
                           where alunoSelected.Nome.Contains(name)
                           select alunoSelected).FirstOrDefault();
            if (aluno != null)
                return Ok(aluno);
            else
                return NotFound("Voce se fudeu hein");
        }

        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
