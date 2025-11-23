namespace Final_Project;

public class PayByCash : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        if (employee is Manager) return employee.Salary;
        var hours = HourLogger.GetInstance().GetTotalHours(employee.ID);
        return employee.HourlyPay * (decimal)hours;
    }

    public void Pay(Employee employee)
    {
        var amt = CalculatePay(employee);
        Console.WriteLine($"Paying cash to {employee.Name} (ID {employee.ID}): {amt:C}");
    }
}
