namespace Final_Project;

class Program
{
    static void Main(string[] args)
    {
        var supermarket = new Supermarket();
        var logger = HourLogger.GetInstance();

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
            Console.WriteLine("7. Exit");
            Console.Write("\nChoose an option: ");
            
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    supermarket.ShowEmployeeList();
                    break;
                case "2":
            }
        }
    }
}