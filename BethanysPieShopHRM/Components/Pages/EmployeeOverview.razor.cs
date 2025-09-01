using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;
        private Employee? _selectedEmployee;

        public readonly string Title = "Employee Overview";

        protected override async Task OnInitializedAsync()
        {
            Employees = MockDataService.Employees;
        }

        public void ShowQuickViewPopup(Employee employee)
        {
            _selectedEmployee = employee;
        }
    }
}
