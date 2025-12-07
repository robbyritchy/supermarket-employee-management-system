namespace Final_Project;

public abstract class Paycheck
{
    public abstract decimal CalculatePay(Employee employee);

    public abstract void ProcessPayment(Employee employee, decimal amount);
    
    //Template method
    public void Pay(Employee employee)
    {
        decimal amount = CalculatePay(employee);
        ProcessPayment(employee, amount);
    }
}
