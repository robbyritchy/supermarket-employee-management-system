namespace Final_Project;

public class PayByDirectDeposit : IPaycheck
{
    public decimal CalculatePay(Employee employee)
    {
        return employee.CalculatePay();
    }

    public void Pay(Employee employee)
    {
        var amt = CalculatePay(employee);
        Console.WriteLine($"Depositing {amt:C} into account for {employee.Name}");
    }
}
