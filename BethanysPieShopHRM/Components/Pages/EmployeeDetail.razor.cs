using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public List<TimeRegistration> TimeRegistrations { get; set; } = [];

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ITimeRegistrationDataService TimeRegistrationDataService { get; set; }

        protected IQueryable<TimeRegistration>? _itemsQueryable;
        protected int _queryableCount = 0;

        public PaginationState Pagination = new PaginationState() { ItemsPerPage = 10 };

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
            _itemsQueryable = TimeRegistrationDataService.GetTimeRegistrationsForEmployee(EmployeeId);
            _queryableCount = _itemsQueryable.Count();
        }

        public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest request)
        {
            int totalNumberOfTimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationCountForEmployeeId(EmployeeId);

            var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
            var listItems = await TimeRegistrationDataService.GetPagedTimeRegistrationsForEmployee(EmployeeId, numberOfTimeRegistrations, request.StartIndex);

            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }
}
