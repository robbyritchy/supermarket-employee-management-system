namespace Final_Project;

public class PayByDirectDeposit : Paycheck
{
    public override decimal CalculatePay(Employee employee)
    {
        return employee.CalculatePay();
    }

    public override void ProcessPayment(Employee employee, decimal amount)
    {
        Console.WriteLine($"Depositing {amount:C} into account for {employee.Name}");
    }
}
