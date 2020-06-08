using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WepApi.Data;
using SmartSchool.WepApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using AutoMapper;
using SmartSchool.WepApi.Dtos;

namespace SmartSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository repo;
        private readonly IMapper imapper;
        public ProfessorController(IRepository repo, IMapper imapper)
        {
            this.repo = repo;
            this.imapper = imapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var professores = repo.GetAllProfessores();
                var professorDto = imapper.Map<IEnumerable<ProfessorDto>>(professores);
                return Ok(professorDto);

            }
            catch (Exception ex )
            {

                return Problem("Erro no servidor");
            }
     

        }

        // GET: api/Aluno/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                Professor professor = repo.GetProfessorById(id, true);
                if (professor != null)
                {
                    var professorDto = imapper.Map<ProfessorDto>(professor);
                    return Ok(professorDto);
                }
           
                else
                    return NotFound("Não encontrado");
            }
            catch (Exception ex)
            {
                

                return Problem("Erro servidor");
            }


        }
        // POST: api/Aluno
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorRegistrarDto model)
        {
            try
            {
                var professor = imapper.Map<Professor>(model);
                repo.Add(professor);
                repo.SaveChanges();

                return Created("/api/Professor", $"{model}");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar Professor");

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