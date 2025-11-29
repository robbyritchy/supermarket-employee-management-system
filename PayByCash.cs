namespace Final_Project;

public class PayByCash : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        return employee.CalculatePay();
    }

    public void Pay(Employee employee)
    {
        var amount = CalculatePay(employee);
        Console.WriteLine($"Paying cash to {employee.Name}: {amount:C}");
    }
}
