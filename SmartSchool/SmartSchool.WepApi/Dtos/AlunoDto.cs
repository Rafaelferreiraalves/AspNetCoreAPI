using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Dtos
{
    public class AlunoDto
    {
        //public int Id { get; set; }
        //public int Matricula { get; set; }
        //public int Idade { get; set; }
        //public DateTime DataInicio { get; set; } 
        //public string Nome { get; set; }
        //public string Telefone { get; set; }

        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno, para outros neg�cios na Institui��o
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome � o Primeiro nome o o Sobrenome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public string Telefone { get; set; }
        /// <summary>
        /// Esta idade � o calculo relacionado a data de nascimento do Aluno
        /// </summary>
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        /// <summary>
        /// Ativar ou n�o o Aluno
        /// </summary>
        public bool Ativo { get; set; }
    }
}
