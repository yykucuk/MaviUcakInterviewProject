using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        IList<T> GetAllByFilter(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool CreateList(List<T> entities);
        //bool UpdateList(T entity);
        bool DeleteList(List<T> entities);
        bool CreateByResult(T entity);
        bool UpdateByResult(T entity);
        bool DeleteByResult(T entity);
        T CreateByEntityResult(T entity);
    }
}
