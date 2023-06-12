using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Result<IEnumerable<Master>>> GetMasters(int salonId, Paging paging);
        Task<Result<IEnumerable<Master>>> GetMastersByService(int salonId, int serviceId, Paging paging);
        Task<Result<Master>> GetMasterById(int masterId);
        Task<Result<MasterWithPhotoAndSalon>> GetMasterAccount();
        Task<Result<MasterWithEmail>> GetManagerMasterById(int masterId);
        Task<Result<IEnumerable<MasterWithEmail>>> GetManagerMasters(Paging paging);
        Task<Result<IEnumerable<MasterWithEmail>>> GetManagerMastersByService(int serviceId, Paging paging);
        Task<Result<IEnumerable<MasterWithEmail>>> GetManagerMastersByServiceCategory(int categoryId, Paging paging);
        Task<Result<IEnumerable<MasterWithEmail>>> GetAvailableMastersToChange(int appointmentId);
        Task<Result<IEnumerable<MasterAppointmentCount>>> GetTopManagerSalonMasters(int top);
        Task<Result<IEnumerable<Employee>>> GetAllEmployees(Paging paging, EmployeeFiltration filtration);
        Task<Result<Employee>> GetEmployeeById(int employeeId);
        Task<Result<string>> CreateEmployee(EmployeeCreate request);
        Task<Result<string>> ChangeEmployee(int employeeId, EmployeeChange request);
        Task<Result<string>> DeleteEmployee(int employeeId);
        Task<Result<string>> AddMasterService(int masterId, int serviceId);
        Task<Result<string>> RemoveMasterService(int masterId, int serviceId);
    }
}
