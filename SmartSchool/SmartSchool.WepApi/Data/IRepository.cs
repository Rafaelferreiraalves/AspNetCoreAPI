using SmartSchool.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class ;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Alunos
        Aluno[] GetAllAlunos(bool includeDisciplinas=false);

        Aluno[] GetAllByDisciplinaId(bool includeDisciplinas=false);
        Aluno[] GetAlunoById(int id, bool includeDisciplinas=false);

        //Professores

        Professor[] GetAllProfessores();

        Professor[] GetAllProfessorByDisciplina();
        Professor[] GetAllProfessoresById();





    }
}
