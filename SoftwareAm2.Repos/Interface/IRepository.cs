using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAm2.Repos.Interface
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetbyId(int Id);
        void Add(TEntity entity);
        void Update(TEntity entityraw, TEntity entity);
        void Delete(TEntity entity);
    }
}
