using MVCUserCrud.Models;

namespace MVCUserCrud.Services
{
    public interface IUserService
    {
        IEnumerable<UserList> GetUsers();
        UserList GetUsersById(int id);
        void AddUser(UserList user);
        void UpdateUser(UserList user);
        void DeleteUser(int id);
    }
}
