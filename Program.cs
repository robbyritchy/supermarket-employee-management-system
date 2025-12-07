using System.Buffers;

namespace Final_Project;

class Program
{
    private static Supermarket supermarket = new Supermarket();
    private static HourLogger logger = HourLogger.GetInstance();
    private static Manager owner;
    
    static void Main(string[] args)
    {
        owner = new Manager("Owner", supermarket.GenerateId(), 5000, supermarket.Employees, logger, PayMethod.Cash);
        //Test employees
        supermarket.Employees[owner.Id] = owner;
        var cashier = EmployeeFactory.CreateEmployee(
            JobType.Cashier,
            "Robby",
            supermarket.GenerateId(),
            15
        );
        supermarket.Employees[cashier.Id] = cashier;

        var stocker = EmployeeFactory.CreateEmployee(
            JobType.Stocker,
            "Angel",
            supermarket.GenerateId(),
            15
        );
        supermarket.Employees[stocker.Id] = stocker;
        

        

        bool running = true;
        
        Console.WriteLine("\n---------- Supermarket Management ----------");
        Console.WriteLine($"For demonstration purposes:");
        Console.WriteLine($"Manager-Test ID: {owner.Id}");
        Console.WriteLine($"Cashier-Test ID: {cashier.Id}");
        Console.WriteLine($"Stocker-Test ID: {stocker.Id}");
        while (true)
        {
            Employee user = Login();
            if (user == null) return;

            if (user is Manager managerUser)
                ManagerMenu(managerUser);
            else
                EmployeeMenu(user);
        }
        
    }

    static Employee Login()
        {
            while (true)
            {
                Console.WriteLine("\nEnter Employee ID (or type 'exit'): ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "exit")
                    return null;

                if (!int.TryParse(input, out int id))
                {
                    Console.WriteLine("Not a valid number.");
                    continue;
                }

                if (supermarket.Employees.TryGetValue(id, out Employee emp))
                {
                    Console.WriteLine($"\nWelcome {emp.Name} ({emp.GetType().Name})");
                    return emp;
                }

                Console.WriteLine("Employee not found.");
            }
        }

        //  MANAGER MENU 
        static void ManagerMenu(Manager manager)
        {
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine("\nManager Menu");
                Console.WriteLine("1. Show Employees");
                Console.WriteLine("2. Hire Employee");
                Console.WriteLine("3. Edit Employee");
                Console.WriteLine("4. Fire Employee");
                Console.WriteLine("5. Log Hours");
                Console.WriteLine("6. View Hours for employee");
                Console.WriteLine("7. Pay Employee");
                Console.WriteLine("8. View Job Description");
                Console.WriteLine("9. View Task List");
                Console.WriteLine("0. Log Out");

                switch (Console.ReadLine())
                {
                    case "1":
                        supermarket.ShowEmployeeList();
                        break;

                    case "2":
                        HireEmployee(supermarket);
                        break;

                    case "3":
                        EditEmployee(supermarket);
                        break;

                    case "4":
                        FireEmployee();
                        break;

                    case "5":
                        LogEmployeeHours();
                        break;

                    case "6":
                        ViewEmployeeHours();
                        break;
                    case "7":
                        PayEmployeeMenu(owner);
                        break;
                    case "8":
                        manager.GetJobDescription();
                        break;

                    case "9":
                        manager.GetTaskList();
                        break;

                    case "0":
                        loggedIn = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // EMPLOYEE MENU 
        static void EmployeeMenu(Employee employee)
        {
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine("\nEmployee Menu");
                Console.WriteLine("1. View Job Description");
                Console.WriteLine("2. View Task List");
                Console.WriteLine("0. Log Out");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(employee.JobDescription);
                        break;
                    case "2":
                        Console.WriteLine(employee.TaskList);
                        break;
                    case "0":
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        
    //Methods for employee control
    
    //Hire Employee method
    static void HireEmployee(Supermarket supermarket)
    {
        Console.WriteLine("Enter employee name: ");
        string name = Console.ReadLine();
        
        Console.WriteLine("Enter job type (Manager, Cashier, Stocker): ");
        string jobInput = Console.ReadLine();

        if (!Enum.TryParse<JobType>(jobInput, true, out var job))
        {
            Console.WriteLine("Invalid job type");
            return;
        }

        int id = supermarket.GenerateId();

        decimal startingPay = job switch
        {
            JobType.Manager => 4000,
            JobType.Cashier => 15,
            JobType.Stocker => 15,
            _ => 15
        };

        Employee emp = EmployeeFactory.CreateEmployee(job, name, id, startingPay);
        if (supermarket.Employees.ContainsKey(id))
        {
            Console.WriteLine("ID already exists, error.");
            return;
        }

        supermarket.Employees[id] = emp;
        Console.WriteLine($"{name} hired as {job} with ID: {id}");
    }
    
    //Edit Employee method
    static void EditEmployee(Supermarket supermarket)
    {
        Console.WriteLine("Enter employee ID to edit: ");

        if (!int.TryParse(Console.ReadLine(), out int id) || !supermarket.Employees.TryGetValue(id, out var employee))
        {
            Console.WriteLine("Employee not found");
            return;
        }
        
        Console.WriteLine("Enter new name (leave blank to skip): ");
        string newName = Console.ReadLine();
        newName = string.IsNullOrWhiteSpace(newName) ? null : newName;
        
        Console.WriteLine("Enter new pay (leave blank to skip): ");
        string payInput = Console.ReadLine();
        decimal? newPay = decimal.TryParse(payInput, out decimal p) ? p : null;
        
        Console.WriteLine("Enter new job type (Manager, Cashier, Stocker, blank to skip): ");
        string typeInput = Console.ReadLine();
        JobType? newType = Enum.TryParse(typeInput, true, out JobType t) ? t : null;

        //Use owner/head manager to edit the employee
        owner.EditEmployee(id, newName, newPay, newType);
    }
    
    //Fire Employee method
    static void FireEmployee()
    {
        Console.WriteLine("Enter employee ID to fire: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            return;
        }
        owner.FireEmployee(id);
    }
    
    //Log employee hours
    static void LogEmployeeHours()
    {
        //Check if employee id exists
        Console.WriteLine("Enter employee ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            return;
        }
        
        //Check input for hours worked
        Console.WriteLine("Enter hours worked");
        if (!double.TryParse(Console.ReadLine(), out double hours))
        {
            return;
        }
        
        logger.AddHours(id, new WorkLogEntry(DateTime.Now, hours));
        Console.WriteLine("Hours logged.");
    }

    static void ViewEmployeeHours()
    {
        Console.WriteLine("Enter employee ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            return;
        }
        logger.DisplayHours(id);
    }

    static void PayEmployeeMenu(Manager manager)
    {
        Console.WriteLine("Enter employee ID to pay: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.WriteLine("Choose payment method:");
        Console.WriteLine("1. Use Employee Preferred Method");
        Console.WriteLine("2. Cash");
        Console.WriteLine("3. Check");
        Console.WriteLine("4. Direct Deposit");

        Paycheck method = null; // --default- (employee's preference)

        switch (Console.ReadLine())
        {
            case "1":
                method = null; // -- use preferred
                break;
            case "2":
                method = new PayByCash();
                break;
            case "3":
                method = new PayByCheck();
                break;
            case "4":
                method = new PayByDirectDeposit();
                break;
            default:
                Console.WriteLine("Invalid choice. Using employee's preferred method.");
                break;
        }

        manager.PayEmployee(id, method);
    }

}

