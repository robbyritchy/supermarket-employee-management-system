namespace Final_Project;

public interface IHourLogger
{
    void AddHours(int employeeId, WorkLogEntry entry);
    IEnumerable<WorkLogEntry> GetEntries(int employeeId);
    double GetTotalHours(int employeeId);
}