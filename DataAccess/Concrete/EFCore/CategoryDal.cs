using DataAccess.Abstract;
using Entities.Models;
using Entities.Data;

namespace DataAccess.Concrete.EFCore
{
    public class CategoryDal : EFCoreGenericRepository<Category, MAVIUCAK_INTERVIEW_PROJECTContext>, ICategoryDal 
    {
    }
}
