namespace Final_Project;
using System;

public class PayByCheck : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        return employee.CalculatePay();
    }

    public void Pay(Employee employee)
    {
        var amt = CalculatePay(employee);
        Console.WriteLine($"Issuing check to {employee.Name}: {amt:C}");
    }
}
