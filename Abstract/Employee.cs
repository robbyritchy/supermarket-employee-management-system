namespace Final_Project;

public abstract class Employee
{
    public string Name { get; set; }
    public int Id { get; private set; }
    public string JobDescription { get; set; }
    public string TaskList { get; set; }
    public Paycheck PaymentMethod {get; set;}
    public PayMethod PreferredPayMethod {get; set;}
    
    public IHourLogger HourLogger { get; }

    protected Employee(string name, int id, IHourLogger logger, PayMethod payMethod)
    {
        Name = name;
        Id = id;
        HourLogger = logger; 
        PreferredPayMethod = payMethod;

        PaymentMethod = payMethod switch
        {
            PayMethod.Cash => new PayByCash(),
            PayMethod.Check => new PayByCheck(),
            PayMethod.DirectDeposit => new PayByDirectDeposit(),
            _ => new PayByCash()
        };
    }
    
    //Method for setting payment method
    public void SetPayMethod(Paycheck payMethod)
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