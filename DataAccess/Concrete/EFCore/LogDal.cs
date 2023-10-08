using DataAccess.Abstract;
using Entities.Models;
using Entities.Data;

namespace DataAccess.Concrete.EFCore
{
    public class LogDal : EFCoreGenericRepository<Log, MAVIUCAK_INTERVIEW_PROJECTContext>, ILogDal
    {
        /// <summary>
        /// It record logs to ms sql
        /// </summary>
        /// <param name="message"></param>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        public void CreateLog(string message, string className, string methodName)
        {
            Log log = new Log();
            log.Message = message;
            log.ClassName = className;
            log.MethodName = methodName;
            log.DateTime = DateTime.Now;

            using (var context = new MAVIUCAK_INTERVIEW_PROJECTContext())
            {
                context.Set<Log>().Add(log);
                context.SaveChanges();
            }
        }
    }
}
