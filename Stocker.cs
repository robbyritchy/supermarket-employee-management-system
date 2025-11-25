namespace Final_Project;

namespace Final_Project;

public class Stocker : Employee
{
    public decimal HourlyPay { get; set; }

    public Stocker(string name, int id, decimal hourlyPay)
        : base(name, id)
    {
        HourlyPay = hourlyPay;
    }
    public void GetJobDescription(){}
    public void GetTaskList(){}
}