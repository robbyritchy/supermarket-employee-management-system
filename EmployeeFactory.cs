namespace Final_Project;

public class EmployeeFactory
{
    public static Employee CreateEmployee(JobType type, string name, int id, decimal? startingPay = null, PayMethod payMethod = PayMethod.Cash)
    {
        var logger = HourLogger.GetInstance();
        Paycheck method = payMethod switch
        {
            PayMethod.Cash => new PayByCash(),
            PayMethod.Check => new PayByCheck(),
            PayMethod.DirectDeposit => new PayByDirectDeposit(),
            _ => new PayByCash()
        };
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

            return new Manager(name, id, pay, new Dictionary<int, Employee>(), logger, payMethod);
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
            return new Cashier(name, id, pay, logger, payMethod);
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
            return new Stocker(name, id, pay, logger, payMethod);
        }
        else
        {
            throw new ArgumentException("Invalid job type");
        }
    }
}