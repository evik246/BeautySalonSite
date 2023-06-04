using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Result<IEnumerable<Master>>> GetMasters(int salonId, Paging paging);
    }
}
