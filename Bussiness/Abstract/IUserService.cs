using Entities.Models;

namespace Bussiness.Abstract
{
    public interface IUserService
    {
        /// <summary>
        /// It gets User by Name and Password
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByNameAndPassword(string name, string password);

        /// <summary>
        /// It gets all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll();

        /// <summary>
        /// It deletes the user by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteByResult(int id);

        /// <summary>
        /// It updates the LastOnlineDate of the user
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserLastOnlineDate(User user);

        /// <summary>
        /// It gets users by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<User> GetUsersByUserId(int id);
    }
}
