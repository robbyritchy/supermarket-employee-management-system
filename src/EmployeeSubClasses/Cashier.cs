namespace Final_Project;

public class Cashier : Employee
{
    public decimal HourlyPay { get; set; }

    public Cashier(string name, int id, decimal hourlyPay, IHourLogger logger, PayMethod payMethod)
        : base(name, id, logger, payMethod)
    {
        HourlyPay = hourlyPay;
        JobDescription = "Handles checkout and assists customers.";
        TaskList = "Refill cash in register.";
    }

    public void GetJobDescription()
    {
        Console.WriteLine(JobDescription);
    }

    public void GetTaskList()
    {
        Console.WriteLine(TaskList);
    }
    public override decimal CalculatePay()
    {
        return HourlyPay * (decimal)GetHoursWorked();
    }
    public override string GetPayInfo()
    {
        return ($"Hourly: {HourlyPay:C}");
    }
}