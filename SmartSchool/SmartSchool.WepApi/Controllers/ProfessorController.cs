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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository repo;
        private readonly IMapper imapper;
        /// <summary>
        /// Construtor da controoler Recebe na injeçao de dependencia um irepository e map
        /// </summary>
        /// <param name="repo">repositorio </param>
        /// <param name="imapper">mapper</param>
        public ProfessorController(IRepository repo, IMapper imapper)
        {
            this.repo = repo;
            this.imapper = imapper;
        }
        /// <summary>
        /// Metodo para listar todos os professores
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Retorna apenas o professor correspondente do ID
        /// </summary>
        /// <param name="id">Id do professor</param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo para cadastrar o professor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorRegistrarDto model)
        {
            try
            {
                var professor = imapper.Map<Professor>(model);
                repo.Add(professor);
                repo.SaveChanges();

                return Created("/api/Professor", $"{ Newtonsoft.Json.JsonConvert.SerializeObject( model)}");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar Professor");

            }
        }

        // PUT: api/Aluno/5
        /// <summary>
        /// Metodo para atualizar as informações do professor por meio do ID
        /// </summary>
        /// <param name="id">I do professor</param>
        /// <param name="model">Corpo da requisicao</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProfessorRegistrarDto model)
        {
            try
            {
                var professor = repo.GetProfessorById(id, true);

                if (id == 0 || professor == null)
                {
                    return BadRequest();
                }

                professor= imapper.Map<Professor>(model);
                repo.Update(professor);
                repo.SaveChanges();

                return Created("/api/Professor", $"{model}");
            }
            catch (Exception ex)
            {

                return Problem("Erro ao criar Professor");
            }
    
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Remove professor
        /// </summary>
        /// <param name="id">Id do professor</param>
        /// <returns></returns>
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