namespace Final_Project;

public abstract class Employee
{
    public string Name { get; set; }
    public int Id { get; private set; }
    public string JobDescription { get; set; }
    public string TaskList { get; set; }
    public PayMethod PaymentMethod {get; set;}
    
    public IHourLogger HourLogger { get; }

    protected Employee(string name, int id, IHourLogger logger, PayMethod payMethod)
    {
        Name = name;
        Id = id;
        HourLogger = logger;
        PaymentMethod = payMethod;
    }
    
    //Method for setting payment method
    public void SetPayMethod(PayMethod payMethod)
    {
        PaymentMethod = payMethod;
    }
    //Methods for logging hours
    public void LogHours(double hours)
    {
        HourLogger.AddHours(Id, new WorkLogEntry(DateTime.Now, hours));
    }

    public double GetHoursWorked()
    {
        return HourLogger.GetTotalHours(Id);
    }
    
    //Include overridable pay strategy for each subclass
    public abstract decimal CalculatePay();
    //Include overridable method to type of pay
    public abstract string GetPayInfo();
}