using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Models;

namespace Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IRoleService _roleService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userDal"></param>
        public UserManager(IUserDal userDal, IRoleService roleService)
        {
            _userDal = userDal;
            _roleService = roleService;
        }

        /// <summary>
        /// It gets Users with including ProjectUserRelations
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return _userDal.GetAll().ToList();
        }

        /// <summary>
        /// It gets the user by name and password
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByNameAndPassword(string name, string password)
        {
            User user = _userDal.GetOne(s => s.Name == name & s.Password == password);
            if(user == null)
            {
                return null;
            }
            user.Role = _roleService.GetById(user.RoleId);
            return user;
        }

        /// <summary>
        /// It deletes user by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteByResult(int id)
        {
            User user = _userDal.GetById(id);
            return _userDal.DeleteByResult(user);
        }

        /// <summary>
        /// It updates the LastOnlineDate of the user
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserLastOnlineDate(User user)
        {
            user.LastOnline = DateTime.Now;
            _userDal.Update(user);
        }

        /// <summary>
        /// It gets users by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<User> GetUsersByUserId(int id)
        {
            return _userDal.GetAllByFilter(s => s.Id == id);
        }
    }
}
