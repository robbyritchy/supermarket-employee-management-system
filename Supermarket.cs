namespace Final_Project;
using System.Collections.Generic;

public class Supermarket
{
    public Dictionary<int, Employee> Employees { get; } = new();

    public void ShowEmployeeList()
    {
        if (Employees.Count == 0)
        {
            System.Console.WriteLine("No employees.");
            return;
        }

        System.Console.WriteLine("Employees:");
        foreach (var kv in Employees)
        {
            var e = kv.Value;
            var role = e.GetType().Name;
            System.Console.WriteLine($"  ID: {e.Id} | Name: {e.Name} | Role: {role} | {e.GetPayInfo()}");
        }
    }
}
