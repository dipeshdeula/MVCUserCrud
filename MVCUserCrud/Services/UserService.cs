using MVCUserCrud.Models;
using MVCUserCrud.Repositories;

namespace MVCUserCrud.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserList> GetUsers()
        {
            return _userRepository.GetAllUserLists();
        }

        public UserList GetUsersById(int id)
        {
             return _userRepository.GetUserById(id);
        }

        public void AddUser(UserList user)
        {
            _userRepository.AddUser(user);
            
        }

        public void UpdateUser(UserList user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
