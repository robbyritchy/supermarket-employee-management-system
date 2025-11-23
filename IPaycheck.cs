namespace Final_Project;

public interface IPaycheck
{
    decimal CalculatePay(Employee employee);
    void Pay(Employee employee);
}
