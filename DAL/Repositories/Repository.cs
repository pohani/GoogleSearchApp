using DAL.Data;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SDbContext _sDbContext;

        public Repository(SDbContext SDbContext) {
            _sDbContext= SDbContext;
        }

        public void Add(T _object)
        {
            _sDbContext.Set<T>().Add(_object);
        }

        public void Delete(T _object)
        {
            _sDbContext.Set<T>().Remove(_object);
        }

        public IEnumerable<T> GetAll()
        {
            return _sDbContext.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _sDbContext.Set<T>().Find(Id);
        }
    }
}
