namespace Final_Project
using System;

public class PayByCheck : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        if (employee is Manager)
        {
            return employee.Salary;
        }
        else
        {
            var hours = HourLogger.GetInstance().GetTotalHours(employee.ID);
            return employee.HourlyPay * (decimal)hours;
        }
    }

    public void Pay(Employee employee)
    {
        var amount = CalculatePay(employee);
        Console.WriteLine($"Issuing check to {employee.Name} (ID {employee.ID}): {amount:C}");
    }
}
