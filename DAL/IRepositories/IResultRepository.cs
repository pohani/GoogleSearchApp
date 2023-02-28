using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IResultRepository : IRepository<Result>
    {
        void AddAll(IEnumerable<Result> results);
        IEnumerable<Result> GetByKeyWordId(int keyWordId);
        IEnumerable<Result> GetByKeyWordIdWithFilter(int keyWordId, string filterWord);
    }
}
