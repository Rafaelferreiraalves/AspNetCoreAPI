using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }
        public Disciplina(int id, string nome, int professorId, int cursoID)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
            this.CursoID = cursoID;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public int? RequisitoId { get; set; }
        public Disciplina Requisito { get; set; } = null;
        public Professor Professor { get; set; }
        public int CargaHoraria { get; set; }
        public int CursoID { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }

    }
}
