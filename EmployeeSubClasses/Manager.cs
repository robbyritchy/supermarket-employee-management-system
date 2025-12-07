namespace Final_Project;

public class Manager : Employee, IManageEmployees, IWork
{
    private readonly Dictionary<int, Employee> _employees;
    public decimal Salary { get; set; }

    public Manager(string name, int id, decimal salary, Dictionary<int, Employee> employees, IHourLogger logger, PayMethod payMethod)
        : base(name, id, logger, payMethod)
    {
        Salary = salary;
        _employees = employees;
        JobDescription = "Oversees employees, manages payment for employees, and controls employee statuses.";
        TaskList = "Pay Employees on Friday at 12 PM. Fire any employees clocking in less than 2 hours weekly.";
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
    public void EditEmployee(int employeeId, string? newName = null, decimal? newPay = null, JobType? newType = null, PayMethod? newPayMethod = null)
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
        //Updates payment method if provided
        if (newPayMethod != null)
        {
            employee.PreferredPayMethod = newPayMethod.Value;
            employee.PaymentMethod = newPayMethod.Value switch
            {
                PayMethod.Cash => new PayByCash(),
                PayMethod.Check => new PayByCheck(),
                PayMethod.DirectDeposit => new PayByDirectDeposit(),
                _ => employee.PaymentMethod
            };
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
            decimal startingPay;
            if (employee is Manager && (newType == JobType.Cashier || newType == JobType.Stocker))
            {
                startingPay = 15;
            }
            else if ((employee is Cashier || employee is Stocker) && newType == JobType.Manager)
            {
                startingPay = 4000;
            }
            else
            {
                if (employee is Manager manager)
                {
                    startingPay = manager.Salary;
                }
                else if (employee is Cashier cashier)
                {
                    startingPay = cashier.HourlyPay;
                }
                else
                {
                    startingPay = ((Stocker)employee).HourlyPay;
                }
                
                //Use factory method
                Employee newEmployee = EmployeeFactory.CreateEmployee(newType.Value, employee.Name, employee.Id, startingPay, employee.PreferredPayMethod);

                _employees[employeeId] = newEmployee;
                Console.WriteLine($"Employee {employee.Name} (ID: {employee.Id}) is now a {newType} with pay {startingPay:C}");
            }
        }
        else if (newName != null || newPay != null)
        {
            Console.WriteLine($"Employee {employee.Name} (ID: {employee.Id}) has been updated");
            return;
        }
    }
    

    public void PayEmployee(int employeeId, Paycheck method)
    {
        if (!_employees.TryGetValue(employeeId, out var employee))
        {
            Console.WriteLine("Employee not found");
            return;
        }

        var paymentMethod = method ?? employee.PaymentMethod;
        paymentMethod.Pay(employee);
    }

    public decimal GetEmployeePay(int employeeId, Paycheck method)
    {
        if (!_employees.TryGetValue(employeeId, out var employee))
        {
            throw new Exception("Employee not found");
        }
        var paymentMethod = method ?? employee.PaymentMethod;
        return paymentMethod.CalculatePay(employee);
    }

    public string GetJobDescriptionFor(int employeeId)
    {
        if (!_employees.TryGetValue(employeeId, out var employee))
        {
            return "Employee not found";
        }

        return employee.JobDescription;
    }

    public void GetTaskListFor(int employeeId)
    {
        if (!_employees.TryGetValue(employeeId, out var employee))
        {
            Console.WriteLine("Employee not found");
            return;
        }
        Console.WriteLine(employee.TaskList);
    }
}