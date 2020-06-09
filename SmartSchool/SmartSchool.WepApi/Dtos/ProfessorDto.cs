using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Dtos
{
    /// <summary>
    /// Professsor DTo sera usada para retorno
    /// </summary>
    public class ProfessorDto
    {
        /// <summary>
        /// chave do professor controle interno
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Registro do professor
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// nome do professor
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Telefone do professor
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Ativo ou nao
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
