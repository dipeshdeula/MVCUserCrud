using MVCUserCrud.Models;

namespace MVCUserCrud.Repositories
{
    public interface IUserRepository 
    {
        IEnumerable<UserList> GetAllUserLists();
        UserList GetUserById(int id);
        void AddUser(UserList user);
        void UpdateUser(UserList user);
        void DeleteUser(int id);
    }
}
