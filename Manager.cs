namespace Final_Project;

public class Manager : IManageEmployees, IWork
{
    public string Name { get; set; }
    public int ID { get; set; }
    public decimal Salary { get; set; }

    //IWork methods
    public void GetJobDescription(){}
    public void GetTaskList(){}
    
    //IManageEmployees methods
    public void HireEmployee(Employee employee){}
    public void FireEmployee(int employeeId){}
    public void PayEmployee(int employeeId){}
    public void EditEmployee(int employeeId, string newName, decimal? newSalaryOrHourly = null){}

    //*** Placeholder value for now, make sure to fix later ***
    public decimal GetEmployeePay(int employeeId, IPaycheck method)
    {
        return 0;
    }
}