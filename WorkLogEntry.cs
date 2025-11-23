namespace Final_Project;
using System;

public class WorkLogEntry
{
    public DateTime Date { get; set; }
    public double Hours { get; set; }

    public WorkLogEntry(DateTime date, double hours)
    {
        Date = date;
        Hours = hours;
    }
}
