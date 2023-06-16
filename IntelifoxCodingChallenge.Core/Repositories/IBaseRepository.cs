﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        Task<int> CountAsync();
    }
}
