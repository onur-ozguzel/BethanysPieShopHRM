using BethanysPieShopHRM.Contracts.Repository;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        //private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public EmployeeRepository(IDbContextFactory<AppDbContext> dbFactory)
        {
            _appDbContext = dbFactory.CreateDbContext();
            //_dbFactory = dbFactory;
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == employeeId);
        }
    }
}