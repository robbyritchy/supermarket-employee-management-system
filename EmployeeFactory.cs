namespace Final_Project;

public class EmployeeFactory
{
    public static Employee CreateEmployee(JobType type, string name, int id, decimal? startingPay = null)
    {
        var logger = HourLogger.GetInstance();
        if (type == JobType.Manager)
        {
            decimal pay;
            if (startingPay != null)
            {
                pay = startingPay.Value;
            }
            else
            {
                pay = 4000;
            }

            return new Manager(name, id, pay, new Dictionary<int, Employee>(), logger);
        }
        else if (type == JobType.Cashier)
        {
            decimal pay;
            if (startingPay != null)
            {
                pay = startingPay.Value;
            }
            else
            {
                pay = 15;
            }
            return new Cashier(name, id, pay, logger);
        }
        else if (type == JobType.Stocker)
        {
            decimal pay;
            if (startingPay != null)
            {
                pay = startingPay.Value;
            }
            else
            {
                pay = 15;
            }
            return new Stocker(name, id, pay, logger);
        }
        else
        {
            throw new ArgumentException("Invalid job type");
        }
    }
}