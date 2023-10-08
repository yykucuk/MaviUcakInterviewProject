using Entities.Models;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEtkinlikDal : IRepository<Etkinlik>
    {
        /// <summary>
        /// It gets Etkinliks with includings
        /// </summary>
        /// <returns></returns>
        public List<Etkinlik> GetAll();

        /// <summary>
        /// It gets Etkinliks with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Etkinlik> GetAllByFilter(Expression<Func<Etkinlik, bool>> filter);

        /// <summary>
        /// It deletes Etkinlik
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByResult(Etkinlik Etkinlik);

        /// <summary>
        /// It gets the Etkinlik with including by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Etkinlik GetById(int id);
    }
}
