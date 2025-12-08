namespace Final_Project;

public class PayByCash : Paycheck
{
    public override decimal CalculatePay(Employee employee)
    {
        return employee.CalculatePay();
    }

    public override void ProcessPayment(Employee employee, decimal amount)
    {
        
        Console.WriteLine($"Paying cash to {employee.Name}: {amount:C}");
    }
}
