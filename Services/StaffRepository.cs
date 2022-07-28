using StaffServiceAPI.Database;
using StaffServiceAPI.Entities;

namespace StaffServiceAPI.Services;
public class StaffRepository : IStaffRepository
{
    public IEnumerable<Employee> GetEmployees()
    {
        throw new Exception("What has just happened?");
        // return StaffDatabase.GetEmployees();
    }
    public Employee LoadJoe()
    {
        throw new KeyNotFoundException("Joe's name is unknown. Please, try again!");
        // return StaffDatabase.GetEmployees().First(e => e.Name == "Joe");
    } 
}