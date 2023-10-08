using Entities.Models;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        /// <summary>
        /// It gets Users with including ProjectUserRelations
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll();

        /// <summary>
        /// It gets Users with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<User> GetAllByFilter(Expression<Func<User, bool>> filter);

        /// <summary>
        /// It gets the User with including ProjectUserRelations by id
        /// </summary>
        /// <returns></returns>
        public User GetById(int id);

        /// <summary>
        /// It deletes user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteByResult(User user);
    }
}
