using IntelifoxCodingChallenge.Core.Models;
using IntelifoxCodingChallenge.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntelifoxDbContext _dbcontext;

        public IBaseRepository<Article> Articles { get; private set; }

        public IBaseRepository<Category> Categories { get; private set; }

        public IBaseRepository<Tag> Tags { get; private set; }

        public IBaseRepository<User> Users { get; private set; }

        public UnitOfWork(IntelifoxDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            Articles = new BaseRepository<Article>(_dbcontext);
            Categories = new BaseRepository<Category>(_dbcontext);
            Tags = new BaseRepository<Tag>(_dbcontext);
            Users = new BaseRepository<User>(_dbcontext);
        }
        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
