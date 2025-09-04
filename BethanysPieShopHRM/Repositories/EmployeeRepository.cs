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

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var addedEmployee = await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();

            return addedEmployee.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var foundEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (foundEmployee != null)
            {
                _appDbContext.Employees.Remove(foundEmployee);
                await _appDbContext.SaveChangesAsync();
            }
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

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var foundEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (foundEmployee != null)
            {
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.BirthDate = employee.BirthDate;
                foundEmployee.Email = employee.Email;
                foundEmployee.Street = employee.Street;
                foundEmployee.Zip = employee.Zip;
                foundEmployee.City = employee.City;
                foundEmployee.CountryId = employee.CountryId;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.Smoker = employee.Smoker;
                foundEmployee.Gender = employee.Gender;
                foundEmployee.JobCategoryId = employee.JobCategoryId;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.Comment = employee.Comment;
                foundEmployee.JoinedDate = employee.JoinedDate;
                foundEmployee.ExitDate = employee.ExitDate;
                foundEmployee.ImageContent = employee.ImageContent;
                foundEmployee.ImageName = employee.ImageName;

                await _appDbContext.SaveChangesAsync();

                return foundEmployee;
            }

            return null;
        }
    }
}