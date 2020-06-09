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
        const string msgErroController = "Erro no servidor";
        private readonly IRepository repo;
        private readonly IMapper imapper;
        /// <summary>
        /// Construtor controller
        /// Recebe via injecao a repositorio e mmaper
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="imapper"></param>
        public AlunoController(IRepository repo, IMapper imapper)
        {
            this.repo = repo;
            this.imapper = imapper;
        }
        // GET: api/Aluno
        /// <summary>
        /// Metodo responsavel por devolver os alunos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var alunos = repo.GetAllAlunos(true);
                var alunosRetorno = imapper.Map<IEnumerable<AlunoDto>>(alunos);
                return Ok(alunosRetorno);
            }
            catch (Exception)
            {

                return Problem(msgErroController);

            }

        }

        // GET: api/Aluno/5
        /// <summary>
        /// Metodo responsavel por filtrar o aluno pelo id
        /// </summary>
        /// <param name="id">Id do Aluno</param>
        /// <returns>Retorna o aluno filtrado</returns>
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
        /// <summary>
        /// Metodo que ira criar o aluno
        /// </summary>
        /// <param name="model">Corpo da requisicao</param>
        /// <returns>Retorna mensagem indicando que o aluno foi criado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] AlunoRegistrarDto model)
        {
            try
            {
                var aluno = imapper.Map<Aluno>(model);
                repo.Add(aluno);
                repo.SaveChanges();
                return Created($"/api/aluno{model.Id}", this.imapper.Map<AlunoDto>(aluno));
            }
            catch (Exception ex)
            {

                return Problem(msgErroController, null, 500, null, null);
            }
        }

        // PUT: api/Aluno/5
        /// <summary>
        /// Atualizar o aluno
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <param name="model">Corpo da requisicao</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlunoRegistrarDto model)
        {
            try
            {
                var aluno = this.repo.GetAlunoById(id);
                if (default(int) == id || aluno == null)
                {
                    return BadRequest();
                }

                this.imapper.Map(model, aluno);

                repo.Update(aluno);
                repo.SaveChanges();

                return Created($"/api/aluno{model.Id}", this.imapper.Map<AlunoDto>(aluno));
            }
            catch (Exception ex)
            {

                return Problem(msgErroController, null, 500, null, null);
            }

        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Remove o aluno
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns></returns>
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
