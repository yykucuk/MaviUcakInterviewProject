namespace Bussiness.Abstract
{
    public interface IProjectUserRelationService
    {
        /// <summary>
        /// It deletes ProjectUserRelation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByResult(int id);
    }
}
