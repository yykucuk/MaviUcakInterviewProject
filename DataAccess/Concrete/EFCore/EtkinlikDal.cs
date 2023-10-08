using DataAccess.Abstract;
using Entities.Models;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace DataAccess.Concrete.EFCore
{
    public class EtkinlikDal : EFCoreGenericRepository<Etkinlik, MAVIUCAK_INTERVIEW_PROJECTContext>, IEtkinlikDal
    {
        /// <summary>
        /// It gets Etkinliks with includings
        /// </summary>
        /// <returns></returns>
        public override List<Etkinlik> GetAll()
        {
            List<Etkinlik> Etkinliks = new List<Etkinlik>();

            try
            {
                using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
                {
                    Etkinliks = context.Etkinliks.ToList();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return Etkinliks;
        }

        /// <summary>
        /// It gets the Etkinlik with including by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Etkinlik GetById(int id)
        {
            Etkinlik Etkinlik = new Etkinlik();
            using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
            {
                try
                {
                    Etkinlik = context.Etkinliks.FirstOrDefault(s=>s.Id == id);
                }
                catch (Exception ex)
                {
                    new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    return null;
                }
            }
            return Etkinlik;
        }

        /// <summary>
        /// It deletes Etkinlik
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool DeleteByResult(Etkinlik Etkinlik)
        {
            int result = 0;
            using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //After that We delete Etkinlik
                        context.Entry(Etkinlik).State = EntityState.Deleted;
                        context.Set<Etkinlik>().Remove(Etkinlik);
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
        /// It gets Etkinliks with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override List<Etkinlik> GetAllByFilter(Expression<Func<Etkinlik, bool>> filter)
        {
            List<Etkinlik> Etkinliks = new List<Etkinlik>();
            try
            {
                using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
                {
                    Etkinliks = context.Etkinliks.Where(filter).ToList();
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            return Etkinliks;
        }
    }
}
