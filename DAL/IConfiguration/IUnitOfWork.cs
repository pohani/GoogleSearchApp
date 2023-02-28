using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IConfiguration
{
    public interface IUnitOfWork : IDisposable
    {
        IResultRepository ResultDataModelRepository { get; }
        IKeyWordRepository KeyWordRepository { get; }

        void Complete();
    }
}
