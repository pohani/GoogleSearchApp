namespace DAL.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Add(T _object);
        void Delete(T _object);
    }
}
