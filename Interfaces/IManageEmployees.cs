namespace Final_Project;

public interface IManageEmployees
{
    void HireEmployee(Employee employee);
    void FireEmployee(int employeeId);
    void PayEmployee(int employeeId, Paycheck method);
    void EditEmployee(int employeeId, string? newName = null, decimal? newPay = null, JobType? newType = null);
    string GetJobDescriptionFor(int employeeId);
    void GetTaskListFor(int employeeId);
    decimal GetEmployeePay(int employeeId, Paycheck method);
}
