namespace Final_Project;

public class Manager : IManageEmployees, IWork
{
    public string Name { get; set; }
    public int ID { get; set; }
    public decimal Salary { get; set; }

    GetJobDescription();
    GetTaskList();

}