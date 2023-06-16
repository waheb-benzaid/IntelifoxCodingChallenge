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
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();

        T Add(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);
    }
}
