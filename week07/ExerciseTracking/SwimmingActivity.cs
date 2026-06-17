public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, double minutes, int laps) : base(date, minutes)
    {
        _laps = _laps;
    }

    public override double GetDistance()
    {
        // 50 meters = 0.05 km
        return _laps * 0.05;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (GetMinutes() / 60);
    }
    
    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}