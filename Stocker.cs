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

    public override decimal CalculatePay()
    {
        var hours = HourLogger.GetInstance().GetTotalHours(Id);
        return HourlyPay * (decimal)hours;
    }

    public override string GetPayInfo()
    {
        return ($"Hourly: {HourlyPay:C}");
    }
}