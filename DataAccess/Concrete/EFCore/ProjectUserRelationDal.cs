using DataAccess.Abstract;
using Entities.Models;
using Entities.Data;

namespace DataAccess.Concrete.EFCore
{
    public class ProjectUserRelationDal : EFCoreGenericRepository<ProjectUserRelation, MAVIUCAK_INTERVIEW_PROJECTContext>, IProjectUserRelationDal
    {
    }
}
