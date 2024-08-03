using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface IUserService 
    {
        Task CreateUser(UserDTO userDto);
        Task UpdateUser(UserDTO userDto);
        Task DeleteUser(int id);
        Task<UserDTO> GetUser(int id);
        Task<UserDTO> GetUserByEmail(string email);
        Task<IEnumerable<UserDTO>> GetUsers();
    }
}

