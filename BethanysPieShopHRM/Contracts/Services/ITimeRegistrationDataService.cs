﻿using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services
{
    public interface ITimeRegistrationDataService
    {
        IQueryable<TimeRegistration> GetTimeRegistrationsForEmployee(int employeeId);
        Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId);
        Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start);
    }
}
