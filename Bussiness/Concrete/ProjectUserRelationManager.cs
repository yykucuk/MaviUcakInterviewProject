
using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Models;

namespace Bussiness.Concrete
{
    public class ProjectUserRelationManager : IProjectUserRelationService
    {
        private IProjectUserRelationDal _projectUserRelationDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectUserRelationDal"></param>
        public ProjectUserRelationManager(IProjectUserRelationDal projectUserRelationDal)
        {
            _projectUserRelationDal = projectUserRelationDal;
        }

        /// <summary>
        /// It deletes ProjectUserRelation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByResult(int id)
        {
            ProjectUserRelation projectUserRelation = _projectUserRelationDal.GetById(id);
            return _projectUserRelationDal.DeleteByResult(projectUserRelation);
        }
    }
}
