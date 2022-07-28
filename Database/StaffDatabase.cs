using StaffServiceAPI.Entities;

namespace StaffServiceAPI.Database;

public class StaffDatabase
{
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee {Id = 1, Name = "Nikita", Salary = 1000},
            new Employee {Id = 2, Name = "Andrew", Salary = 500},
            new Employee {Id = 3, Name = "Joe", Salary = 7000}
        };
    }
}