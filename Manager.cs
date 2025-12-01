namespace Final_Project;

public class Manager : Employee, IManageEmployees, IWork
{
    private readonly Dictionary<int, Employee> _employees;
    public decimal Salary { get; set; }

    public Manager(string name, int id, decimal salary, Dictionary<int, Employee> employees)
        : base(name, id)
    {
        Salary = salary;
        _employees = employees;
    }
    
    //Employee Superclass method
    public override decimal CalculatePay()
    {
        return Salary;
    }
    public override string GetPayInfo()
    {
        return ($"Salary: {Salary:C}");
    }

    //IWork methods
    public void GetJobDescription(){}
    public void GetTaskList(){}
    
    //IManageEmployees methods
    public void HireEmployee(Employee employee)
    {
        if (_employees.ContainsKey(employee.Id))
        {
            Console.WriteLine($"Employee with ID {employee.Id} already exists");
            return;
        }
        else
        {
            _employees[employee.Id] = employee;
            Console.WriteLine($"Hired {employee.Name} (ID: {employee.Id})");
        }
    }

    public void FireEmployee(int employeeId)
    {
        if (_employees.TryGetValue(employeeId, out var employee))
        {
            Console.WriteLine($"Employee {employee.Name} (ID: {employee.Id}) has been fired");
            _employees.Remove(employee.Id);
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }
    //changes any aspect of an employee instance
    public void EditEmployee(int employeeId, string? newName = null, decimal? newPay = null, JobType? newType = null)
    {
        if (!_employees.TryGetValue(employeeId, out var employee))
        {
            Console.WriteLine("Employee not found");
            return;
        }
        //Changes name if not left empty
        if (!string.IsNullOrWhiteSpace(newName))
        {
            employee.Name = newName;
        }
        //Updates pay if it is provided
        if (newPay != null)
        {
            if (employee is Manager manager)
            {
                manager.Salary = newPay.Value;
            }
            else if (employee is Cashier cashier)
            {
                cashier.HourlyPay = newPay.Value;
            }
            else if (employee is Stocker stocker)
            {
                stocker.HourlyPay = newPay.Value;
            }
        }
        //Use switch statement to set job type to associated class
        Type targetType = newType switch
        {
            JobType.Manager => typeof(Manager),
            JobType.Cashier => typeof(Cashier),
            JobType.Stocker => typeof(Stocker),
            _ => typeof(Manager),
        };
        //Change employee job type if requested
        if (newType != null && employee.GetType() != targetType)
        {
            Employee newEmployee = null;

            if (newType == JobType.Manager)
            {
                decimal startingPay = 4000;
                newEmployee = new Manager(employee.Name, employee.Id, startingPay, _employees);
            }
            else if (newType == JobType.Cashier)
            {
                decimal startingPay = 15;
                newEmployee = new Cashier(employee.Name, employee.Id, startingPay);
            }
            else if (newType == JobType.Stocker)
            {
                decimal startingPay = 15;
                newEmployee = new Cashier(employee.Name, employee.Id, startingPay);
            }
            _employees[employee.Id] = newEmployee;
            Console.WriteLine($"Employee {employee.Name}  (ID: {employee.Id}) is not a {newType} with starting pay.");
        }
        else if (newName != null | newPay != null)
        {
            Console.WriteLine($"Employee {employee.Name} (ID: {employee.Id}) has been updated");
        }
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