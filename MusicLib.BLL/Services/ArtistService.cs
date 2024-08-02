using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateRole(RoleDTO roleDto)
        {
            var role = new Role
            {
                Id = roleDto.Id,
                Name = roleDto.Name
            };
            await Database.Roles.Create(role);

            await Database.Save();
        }

        public async Task UpdateRole(RoleDTO roleDto)
        {
            var role = new Role
            {
                Id = roleDto.Id,
                Name = roleDto.Name
            };
            Database.Roles.Update(role);

            await Database.Save();
        }

        public async Task DeleteRole(int id)
        {
            try 
            { 
                await Database.Roles.Delete(id);

                await Database.Save();            
            } 
            catch (Exception ex)
            {

            }
}

        public async Task<RoleDTO> GetRole(int id)
        {
            var role = await Database.Roles.Get(id);

            if (role == null)
                throw new ValidationException("Wrong role!", "");

            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.
        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(await Database.Roles.GetAll());
        }
    }
}
