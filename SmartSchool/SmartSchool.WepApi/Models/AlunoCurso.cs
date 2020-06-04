using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Models
{
    public class AlunoCurso
    {
        public AlunoCurso()
        {

        }

        public AlunoCurso(int alunoId, int cursoId)
        {
            this.AlunoId = alunoId;
            this.CursoId = cursoId;
        }

        public int AlunoId { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }
        public int? Nota { get; set; } = null;
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
