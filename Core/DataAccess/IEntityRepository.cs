using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //Expression filtreleme yapmayı sağlar
        T Get(Expression<Func<T, bool>> filter); //Tek bir datayı getirmek için

        void Add(T entity);
        void update(T entity);
        void Delete(T entity);

    }
}
