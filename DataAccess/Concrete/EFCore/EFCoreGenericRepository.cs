using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace DataAccess.Concrete.EFCore
{
    public class EFCoreGenericRepository<T, TContext> : IRepository<T> where T : class where TContext : DbContext, new()
    {

        public virtual IList<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<T>().Where(filter).ToList();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return new List<T>();
            }
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<T>().Where(filter).AsQueryable();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return new List<T>();
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<T>().Find(id);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public virtual T GetOne(Expression<Func<T, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<T>().Where(filter).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public virtual void Create(T entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    //context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
        }


        public virtual void Update(T entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
        }

        public virtual bool CreateByResult(T entity)
        {
            try
            {
                var result = 0;
                using (var context = new TContext())
                {
                    context.Set<T>().Add(entity);
                    result = context.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public virtual bool UpdateByResult(T entity)
        {
            try
            {
                var result = 0;
                using (var context = new TContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    result = context.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public virtual bool DeleteByResult(T entity)
        {
            try
            {
                var result = 0;

                using (var context = new TContext())
                {
                    //context.Configuration.ValidateOnSaveEnabled = false;
                    context.Entry(entity).State = EntityState.Deleted;
                    //context.Set<T>().Remove(entity);
                    result = context.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public virtual bool CreateList(List<T> entities)
        {
            bool isResult = false;
            using (var context = new TContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //your db operations

                        context.Set<T>().AddRange(entities);
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                        isResult = true;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        isResult = false;
                    }
                }
            }
            return isResult;
        }

        public virtual bool DeleteList(List<T> entities)
        {
            bool isResult = false;
            using (var context = new TContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //your db operations
                        //context.Configuration.ValidateOnSaveEnabled = false;
                        foreach (T entity in entities)
                        {
                            context.Entry(entity).State = EntityState.Deleted;
                        }

                        context.Set<T>().RemoveRange(entities);
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                        isResult = true;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        isResult = false;
                    }
                }
            }
            return isResult;
        }

        public virtual T CreateByEntityResult(T entity)
        {
            try
            {
                var result = 0;
                using (var context = new TContext())
                {
                    context.Set<T>().Add(entity);
                    result = context.SaveChanges();
                }
                return entity;
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }
    }
}
