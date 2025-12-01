namespace Final_Project;

class Program
{
    static void Main(string[] args)
    {
        var supermarket = new Supermarket();
        var owner = new Manager("Owner", supermarket.GenerateId(), 5000, supermarket.Employees);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n---------- Supermarket Management ----------");
            Console.WriteLine("1. Show Employees");
            Console.WriteLine("2. Hire Employee");
            Console.WriteLine("3. Edit Employee");
            Console.WriteLine("4. Fire employee");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option: ");
            
            string input = Console.ReadLine();

            switch (input)
            {
                
            }
        }
    }
}