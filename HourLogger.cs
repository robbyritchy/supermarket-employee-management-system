using System;
using System.Collections.Generic;
using System.Linq;
namespace Final_Project;

public class HourLogger
{
    private static HourLogger _instance;
    private readonly Dictionary<int, List<WorkLogEntry>> _logs = new();

    private HourLogger() { }

    public static HourLogger GetInstance()
    {
        if (_instance == null) _instance = new HourLogger();
        return _instance;
    }

    public void AddHours(int employeeId, WorkLogEntry entry)
    {
        if (!_logs.ContainsKey(employeeId)) _logs[employeeId] = new List<WorkLogEntry>();
        _logs[employeeId].Add(entry);
    }

    public IEnumerable<WorkLogEntry> GetEntries(int employeeId)
    {
        if (_logs.TryGetValue(employeeId, out var list)) return list;
        return Enumerable.Empty<WorkLogEntry>();
    }

    public double GetTotalHours(int employeeId)
    {
        return GetEntries(employeeId).Sum(e => e.Hours);
    }

    public void DisplayHours(int employeeId)
    {
        var entries = GetEntries(employeeId).ToList();
        if (!entries.Any())
        {
            Console.WriteLine($"No hours logged for employee {employeeId}.");
            return;
        }

        Console.WriteLine($"Hours for employee {employeeId}:");
        foreach (var e in entries)
            Console.WriteLine($"  {e.Date:d} - {e.Hours} hours");
        Console.WriteLine($"  Total: {GetTotalHours(employeeId)} hours");
    }
}
