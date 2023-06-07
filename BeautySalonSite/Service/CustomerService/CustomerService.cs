using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.ErrorModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<FullCustomer>>> GetAllCustomers(Paging paging)
        {
            var customers = await _httpClient.GetFromJsonAsync<IEnumerable<FullCustomer>>($"Customer/manager/account?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (customers == null)
            {
                return new Result<IEnumerable<FullCustomer>>(new ServerException());
            }
            return new Result<IEnumerable<FullCustomer>>(customers);
        }

        public async Task<Result<Customer>> GetCustomer()
        {
            Customer? customer = await _httpClient.GetFromJsonAsync<Customer>("customer/account");

            if (customer == null)
            {
                return new Result<Customer>(new ServerException());
            }

            return new Result<Customer>(customer);
        }

        public async Task<Result<string>> UpdateCustomer(CustomerUpdate request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("customer/account", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

                if (errorResponse?.Errors != null && errorResponse.Errors.ContainsKey(""))
                {
                    var errorMessage = errorResponse.Errors[""][0];
                    if (errorMessage.Equals("At least one property must be specified"))
                    {
                        return new Result<string>(new NoInputContentException());
                    }
                }
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var error = await response.Content.ReadFromJsonAsync<Error>();

                if (error is not null && error.Message.Equals("This email is already used"))
                {
                    return new Result<string>(new UsedEmailException());
                }

                if (error is not null && error.Message.Equals("This phone number is already used"))
                {
                    return new Result<string>(new UsedPhoneException());
                }
            }
            return new Result<string>(new ServerException());
        }
    }
}
