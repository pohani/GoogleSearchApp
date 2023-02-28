using DAL.Data;
using DAL.IRepositories;
using DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IConfiguration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SDbContext _sDbContext;
        public IResultRepository ResultDataModelRepository { get; set; }
        public IKeyWordRepository KeyWordRepository { get; set; }


        public UnitOfWork(SDbContext sDbContext) {
            _sDbContext = sDbContext;

            ResultDataModelRepository = new ResultRepository(_sDbContext);
            KeyWordRepository = new KeyWordRepository(_sDbContext);
        }

        public void Complete()
        {
            _sDbContext.SaveChanges();
        }

        public void Dispose() { 
            _sDbContext.Dispose();
        }

    }
}
