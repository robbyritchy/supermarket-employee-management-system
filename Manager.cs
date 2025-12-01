namespace Final_Project;

public class Manager : Employee, IManageEmployees, IWork
{
    public string Name { get; set; }
    public int ID { get; set; }
    public decimal Salary { get; set; }

    public Manager(string name, int id, decimal salary)
        : base(name, id)
    {
        Salary = salary;
    }
    
    //Employee Superclass method
    public override decimal CalculatePay()
    {
        return Salary;
    }

    //IWork methods
    public void GetJobDescription(){}
    public void GetTaskList(){}
    
    //IManageEmployees methods
    public void HireEmployee(Employee employee){}
    public void FireEmployee(int employeeId){}
    public void EditEmployee(int employeeId, string newName, decimal? newSalaryOrHourly = null){}

    public override string GetPayInfo()
    {
        return ($"Salary: {Salary:C}");
    }

    //*** Placeholder value for now, make sure to fix later ***
    public void PayEmployee(int employeeId, IPaycheck method)
    {
        throw new NotImplementedException();
    }

    public decimal GetEmployeePay(int employeeId, IPaycheck method)
    {
        throw new NotImplementedException();
    }

    public string GetJobDescriptionFor(int employeeId)
    {
        throw new NotImplementedException();
    }

    public void GetTaskListFor(int employeeId){}
}