using System.Buffers;

namespace Final_Project;

class Program
{
    private static Supermarket supermarket = new Supermarket();
    private static HourLogger logger = HourLogger.GetInstance();
    private static Manager owner;
    static void Main(string[] args)
    {
        owner = new Manager("Owner", supermarket.GenerateId(), 5000, supermarket.Employees, logger);

        bool running = true;
        
        Console.WriteLine("\n---------- Supermarket Management ----------");

        while (running)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Show Employees");
            Console.WriteLine("2. Hire Employee");
            Console.WriteLine("3. Edit Employee");
            Console.WriteLine("4. Fire employee");
            Console.WriteLine("5. Log Hours");
            Console.WriteLine("6. View Hours for employee");
            Console.WriteLine("0. Exit");
            Console.Write("\nChoose an option: ");
            
            string input = Console.ReadLine();

            switch (input)
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
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option");
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
}

