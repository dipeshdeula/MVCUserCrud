using MVCUserCrud.Models;

namespace MVCUserCrud.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MvcuserCrudContext _appContext;

        public UserRepository(MvcuserCrudContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<UserList> GetAllUserLists()
        {
            var userList = _appContext.UserLists.ToList();
            return userList;
        }

        public UserList GetUserById(int id)
        {

            var userById = _appContext.UserLists.Where(x => x.UserId == id).FirstOrDefault();
            if (userById == null)
            {
                throw new Exception("User not found");
            }
            return userById;
            // return UserList().Where(x => x.Id == id).First();
        }

        public void AddUser(UserList user)
        {
        }
        public void UpdateUser(UserList user)
        {
        }
        public void DeleteUser(int id)
        {


        }
    }
}
