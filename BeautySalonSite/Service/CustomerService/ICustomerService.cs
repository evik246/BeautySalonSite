﻿using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<Result<Customer>> GetCustomer();
        Task<Result<string>> UpdateCustomer(CustomerUpdate request);
        Task<Result<IEnumerable<FullCustomer>>> GetAllCustomers(Paging paging);
    }
}
