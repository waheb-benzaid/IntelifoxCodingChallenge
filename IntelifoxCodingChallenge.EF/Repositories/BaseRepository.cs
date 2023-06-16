using IntelifoxCodingChallenge.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public T Find(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>().SingleOrDefault(predicate);

        public IEnumerable<T> GetAll() => _dbContext.Set<T>().ToList();


        public T GetById(int id) => _dbContext.Set<T>().Find(id);

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
    }
}
