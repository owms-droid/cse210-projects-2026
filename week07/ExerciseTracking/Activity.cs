using System;
using System.Dynamic;

public abstract class Activity
{
    private string _date;
    private double _minutes;

    public Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public double GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name.Replace("Activity", "")} ({_minutes} min): " +
        $"Distance {GetDistance():F2} km, " +
        $"Speed {GetSpeed():F2} kph, " +
        $"Pace {GetPace():F2} min per km";
    }
}