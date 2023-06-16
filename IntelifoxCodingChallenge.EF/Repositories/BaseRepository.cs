using IntelifoxCodingChallenge.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using IntelifoxCodingChallenge.Core.Models;

namespace IntelifoxCodingChallenge.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected IntelifoxDbContext _dbContext;
        public BaseRepository(IntelifoxDbContext dbContext) // injection
        {
            _dbContext = dbContext;
        }

        //TODO: test if the params are null for all those methods

        public IEnumerable<T> GetAll() => _dbContext.Set<T>().ToList();

        public T GetById(int id) => _dbContext.Set<T>().Find(id);

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
            return entities;
        }
    }
}
