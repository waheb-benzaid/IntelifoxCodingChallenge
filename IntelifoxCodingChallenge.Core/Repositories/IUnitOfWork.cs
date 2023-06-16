using IntelifoxCodingChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Article> Articles { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Tag> Tags { get; }
        IBaseRepository<User> Users { get; }

        int Complete(); // this method will return the number of rows affected by a transaction
    }
}
