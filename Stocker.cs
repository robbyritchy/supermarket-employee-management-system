namespace Final_Project;

public class Stocker : Employee
{
    public decimal HourlyPay { get; set; }

    public Stocker(string name, int id, decimal hourlyPay, IHourLogger logger)
        : base(name, id, logger)
    {
        HourlyPay = hourlyPay;
        JobDescription = "Restocks shelves and manages inventory.";
        TaskList = "Count current inventory.";
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