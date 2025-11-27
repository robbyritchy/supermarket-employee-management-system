namespace Final_Project;

public class PayByCash : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        if (employee is Manager manager)
        {
            return manager.Salary;
        }

        if (employee is Cashier cashier)
        {
            var hours = HourLogger.GetInstance().GetTotalHours(employee.Id);
            return cashier.HourlyPay * (decimal)hours;
        }
    }

    public void Pay(Employee employee)
    {
        var amt = CalculatePay(employee);
        Console.WriteLine($"Paying cash to {employee.Name} (ID {employee.Id}): {amt:C}");
    }
}
