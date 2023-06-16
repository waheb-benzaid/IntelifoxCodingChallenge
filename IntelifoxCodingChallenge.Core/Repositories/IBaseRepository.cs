using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        //the difference between GetById and Find is that Find uses a predicate param, so we can filter by anything
        T Find(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();
    }
}
