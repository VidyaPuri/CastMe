using ZenProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZenProject.Data
{
    public interface IStaffRepository
    {
        // general
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Staff
        Task<Staff[]> GetAllAsync();
        Task<Staff> GetStaffMemberAsync(int id);
    }
}
