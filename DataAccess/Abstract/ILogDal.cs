using Entities.Models;

namespace DataAccess.Abstract
{
    public interface ILogDal : IRepository<Log>
    {
        void CreateLog(string message, string className, string methodName);
    }
}
