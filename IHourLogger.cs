namespace Final_Project;

public interface IHourLogger
{
    void AddHours(int employeeId, WorkLogEntry entry);
    IEnumerable<WorkLogEntry> GetHours(int employeeId);
    double GetTotalHours(int employeeId);
}