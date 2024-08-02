using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface IRoleService
    {
        Task CreateRole(RoleDTO roleDto);
        Task UpdateRole(RoleDTO roleDto);
        Task DeleteRole(int id);
        Task<RoleDTO> GetRole(int id);
        Task<IEnumerable<RoleDTO>> GetRoles();
    }
}
