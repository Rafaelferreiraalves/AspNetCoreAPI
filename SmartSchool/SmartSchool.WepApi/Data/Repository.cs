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

        public Aluno[] GetAllByDisciplinaId(int disciplicaId,bool includeDisciplinas = false)
        {
            IQueryable<Aluno> query = context.Alunos;
            if (includeDisciplinas)
            {
                query = query.Include(aluno => aluno.AlunoDisciplina)
                    .ThenInclude(disciplina => disciplina.Disciplina).ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().Where(aluno => aluno.AlunoDisciplina.Any(x => x.DisciplinaId == disciplicaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int id, bool includeDisciplinas = false)
        {
            IQueryable<Aluno> query = context.Alunos;
            if (includeDisciplinas)
            {
                query = query.Include(aluno => aluno.AlunoDisciplina)
                    .ThenInclude(disciplina => disciplina.Disciplina).ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().Where(aluno => aluno.Id == id);

            return query.FirstOrDefault();

        }

        public Professor[] GetAllProfessores(bool includeDisciplinas = false)
        {
            IQueryable<Professor> query = context.Professor;
            if (includeDisciplinas)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunoDisciplina)
                    .ThenInclude(d => d.Aluno);
                   
            }
            return query.AsTracking().ToArray();
        }

        public Professor[] GetAllProfessorByDisciplina(int disciplinaId,bool includeDisciplinas=false)
        {
            IQueryable<Professor> query = context.Professor;
            if (includeDisciplinas)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunoDisciplina)
                    .ThenInclude(d => d.Aluno);

            }

            query = query.AsNoTracking().Where(x => x.Disciplinas.Any(x => x.AlunoDisciplina.Any(x => x.DisciplinaId == disciplinaId)));

            return query.AsTracking().ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeDisciplinas = false)
        {
            IQueryable<Professor> query = context.Professor;
            if (includeDisciplinas)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunoDisciplina)
                    .ThenInclude(d => d.Aluno);

            }

            query = query.AsNoTracking().Where(x => x.Id == professorId);
            return query.FirstOrDefault();
        }

    
    }
}
