namespace Final_Project;

public abstract class Employee
{
    public string Name { get; set; }
    public int Id { get; private set; }

    protected Employee(string name, int id)
    {
        Name = name;
        Id = id;
    }
    
    //Include pay strategy for each subclass
    public abstract decimal CalculatePay();
}