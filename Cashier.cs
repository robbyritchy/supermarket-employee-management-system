namespace Final_Project;

public class Cashier : Employee
{
    public decimal HourlyPay { get; set; }

    public Cashier(string name, int id, decimal hourlyPay, IHourLogger logger)
        : base(name, id, logger)
    {
        HourlyPay = hourlyPay;
    }
    public void GetJobDescription(){}
    public void GetTaskList(){}
    public override decimal CalculatePay()
    {
        return HourlyPay * (decimal)GetHoursWorked();
    }
    public override string GetPayInfo()
    {
        return ($"Hourly: {HourlyPay:C}");
    }
}