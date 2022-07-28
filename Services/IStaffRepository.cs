using StaffServiceAPI.Entities;

namespace StaffServiceAPI.Services;

public interface IStaffRepository
{
    public IEnumerable<Employee> GetEmployees();
    public Employee LoadJoe();
}