using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.EF;

namespace MusicLib.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private MusicLibContext db;

        public RoleRepository(MusicLibContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await db.Roles.ToListAsync();
        }

        public async Task<Role> Get(int id)
        {
            Role? role = await db.Roles.FindAsync(id);
            return role!;
        }

        public async Task<Role> Get(string name)
        {
            var roles = await db.Roles.Where(a => a.Name == name).ToListAsync();
            Role? role = roles?.FirstOrDefault();
            return role!;
        }

        public async Task Create(Role role)
        {
            await db.Roles.AddAsync(role);
        }

        public void Update(Role role)
        {
            db.Entry(role).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Role? role = await db.Roles.FindAsync(id);
            if (role != null)
                db.Roles.Remove(role);
        }
    }
}
