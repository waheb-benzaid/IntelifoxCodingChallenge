using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.EF
{
    public class IntelifoxDbContext : DbContext
    {
        public IntelifoxDbContext(DbContextOptions<IntelifoxDbContext> options):base(options)
        {
        }
    }
}
