namespace Final_Project;

public class EmployeeFactory
{
    public static Employee CreateEmployee(JobType type, string name, int id, decimal? startingPay = null)
    {
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

            return new Manager(name, id, pay, new Dictionary<int, Employee>());
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
            return new Cashier(name, id, pay);
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
            return new Stocker(name, id, pay);
        }
        else
        {
            throw new ArgumentException("Invalid job type");
        }
    }
}