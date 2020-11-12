using ZenProject.Data;
using ZenProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ZenProject.API.Data
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _appDbContext;

        public StaffRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        public async Task<Staff[]> GetAllAsync()
        {
            IQueryable<Staff> staffMembers = _appDbContext.StaffMembers;
            return await staffMembers.ToArrayAsync();
        }

        public async Task<Staff> GetStaffMemberAsync(int id)
        {
            IQueryable<Staff> staffMember = _appDbContext.StaffMembers
                                                    .Where(tm => tm.StaffId == id);

            return await staffMember.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }
    }
}
