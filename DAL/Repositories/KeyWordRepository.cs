using DAL.Data;
using DAL.IRepositories;
using DAL.Models;

namespace DAL.Repositories
{
    public class KeyWordRepository : Repository<KeyWord>, IKeyWordRepository
    {
        public KeyWordRepository(SDbContext sDbContext) : base(sDbContext)
        { 
        }


        public IEnumerable<KeyWord> GetAll()
        {
            return _sDbContext.KeyWords.ToList();

        }

        public void Add(KeyWord _object)
        {
            _sDbContext.KeyWords.Add(_object);
        }


        public KeyWord GetById(int Id)
        {
            return _sDbContext.KeyWords.Find(Id);
        }

        public void Delete(KeyWord _object)
        {
            _sDbContext.KeyWords.Remove(_object);
        }

        public KeyWord GetByWord(String word)
        {
            return _sDbContext.KeyWords.Where(x => x.Word == word).FirstOrDefault(); ;
        }

    }
}
