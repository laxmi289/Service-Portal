using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePortal.Api.Models.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments ()
        {
            return await appDbContext.Department.ToListAsync();
        }

        public async Task<Department> AddDepartment(Department dept)
        {
            var result = await appDbContext.Department.AddAsync(dept);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
