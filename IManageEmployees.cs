namespace Final_Project;

public interface IManageEmployees
{
    void HireEmployee(Employee employee);
    void FireEmployee(int employeeId);
    void PayEmployee(int employeeId, IPaycheck method);
    void EditEmployee(int employeeId, string newName, decimal? newSalaryOrHourly = null);
    string GetJobDescriptionFor(int employeeId);
    void GetTaskListFor(int employeeId);
    decimal GetEmployeePay(int employeeId, IPaycheck method);
}
