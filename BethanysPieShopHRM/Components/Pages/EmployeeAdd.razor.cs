using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeAdd
    {
        [SupplyParameterFromForm]
        public Employee Employee { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        protected string Message = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Employee ??= new Employee();
        }

        private async Task OnSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            IsSaved = true;
            Message = "Employee added successfully.";
        }
    }
}