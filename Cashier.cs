namespace Final_Project;

public class Cashier : Employee
{
    public decimal HourlyPay { get; set; }

    public Cashier(string name, int id, decimal hourlyPay)
        : base(name, id)
    {
        HourlyPay = hourlyPay;
    }
    public void GetJobDescription(){}
    public void GetTaskList(){}
}