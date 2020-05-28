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

     
    }
}
