using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts;
using Employees.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository
{
    public abstract class RepositoryBase<T>:IRepositoryBase<T> where T:class
    {
        protected AdventureWorks2019Context repositoryContext;

        public RepositoryBase(AdventureWorks2019Context repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            repositoryContext?.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        =>
            !trackChanges ? repositoryContext.Set<T>().AsNoTracking() : repositoryContext.Set<T>();
        

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expressions, bool trackChanges)
        =>
            !trackChanges ? repositoryContext.Set<T>().Where(expressions).AsNoTracking() : repositoryContext.Set<T>().Where(expressions);
        

        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
        }
    }
}
