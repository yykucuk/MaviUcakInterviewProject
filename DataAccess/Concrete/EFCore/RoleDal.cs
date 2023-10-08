using DataAccess.Abstract;
using Entities.Models;
using Entities.Data;

namespace DataAccess.Concrete.EFCore
{
    public class RoleDal : EFCoreGenericRepository<Role, MAVIUCAK_INTERVIEW_PROJECTContext>, IRoleDal //MAVIUCAK_INTERVIEW_PROJECTContext
    {
    }
}
