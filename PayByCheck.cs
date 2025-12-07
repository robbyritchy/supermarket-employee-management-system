namespace Final_Project;
using System;

public class PayByCheck : Paycheck
{
    public override decimal CalculatePay(Employee employee)
    {
        return employee.CalculatePay();
    }

    public override void ProcessPayment(Employee employee, decimal amount)
    {
        Console.WriteLine($"Issuing check to {employee.Name}: {amount:C}");
    }
}
