using Microsoft.EntityFrameworkCore;
using SmartSchool.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;
        public Repository(DataContext context)
        {
            this.context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
          
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0 ;
        }

        public Aluno[] GetAllAlunos(bool includeDisciplinas = false)
        {
            IQueryable<Aluno> query = context.Alunos;
            if (includeDisciplinas)
            {
                query = query.Include(aluno => aluno.AlunoDisciplina)
                    .ThenInclude(disciplina => disciplina.Disciplina).ThenInclude(d => d.Professor);
            }          

            query = query.AsNoTracking().OrderBy(aluno => aluno.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllByDisciplinaId(bool includeDisciplinas = false)
        {
            IQueryable<Aluno> query = context.Alunos;
            if (includeDisciplinas)
            {
                query = query.Include(aluno => aluno.AlunoDisciplina)
                    .ThenInclude(disciplina => disciplina.Disciplina).ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking();

            return query.ToArray();
        }

        public Aluno[] GetAlunoById(int id, bool includeDisciplinas = false)
        {
            IQueryable<Aluno> query = context.Alunos;
            if (includeDisciplinas)
            {
                query = query.Include(aluno => aluno.AlunoDisciplina)
                    .ThenInclude(disciplina => disciplina.Disciplina).ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().Where(aluno => aluno.Id == id);

            return query.ToArray();

        }

        public Professor[] GetAllProfessores()
        {
            throw new NotImplementedException();
        }

        public Professor[] GetAllProfessorByDisciplina()
        {
            throw new NotImplementedException();
        }

        public Professor[] GetAllProfessoresById()
        {
            throw new NotImplementedException();
        }
    }
}
