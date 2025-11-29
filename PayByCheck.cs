namespace Final_Project;
using System;

public class PayByCheck : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        if (employee is Manager manager)
        {
            return manager.Salary;
        }
        else if (employee is Cashier cashier)
        {
            var hours = HourLogger.GetInstance().GetTotalHours(employee.ID);
            return cashier.HourlyPay * (decimal)hours;
        }
        else
        {
            throw new InvalidOperationException("Unknown employee type");
        }
    }

    public void Pay(Employee employee)
    {
        var amount = CalculatePay(employee);
        Console.WriteLine($"Issuing check to {employee.Name} (ID {employee.Id}): {amount:C}");
    }
}
