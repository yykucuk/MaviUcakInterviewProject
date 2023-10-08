using DataAccess.Abstract;
using Entities.Models;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace DataAccess.Concrete.EFCore
{
    public class UserDal : EFCoreGenericRepository<User, MAVIUCAK_INTERVIEW_PROJECTContext>, IUserDal
    {

        /// <summary>
        /// It gets Users with including projects
        /// </summary>
        /// <returns></returns>
        public override List<User> GetAll()
        {
            List<User> users = new List<User>();

            try
            {
                using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
                {
                    users = context.Users.Include(i=>i.Role).ToList();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return users;
        }

        /// <summary>
        /// It gets the User with including ProjectUserRelations by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override User GetById(int id)
        {
            User user = new User();

            try
            {
                using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
                {
                    user = context.Users.FirstOrDefault(s=>s.Id == id);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return user;
        }

        /// <summary>
        /// It deletes user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool DeleteByResult(User user)
        {
            int result = 0;
            using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //After that We delete User
                        context.Entry(user).State = EntityState.Deleted;
                        context.Set<User>().Remove(user);
                        result = context.SaveChanges();

                        dbContextTransaction.Commit();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// It gets Users with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override List<User> GetAllByFilter(Expression<Func<User, bool>> filter)
        {
            List<User> users = new List<User>();

            try
            {
                using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
                {
                    users = context.Users.Where(filter).Include(i => i.Role).ToList();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return users;
        }
    }
}
