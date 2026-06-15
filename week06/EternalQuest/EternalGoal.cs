using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never completed, so we do nothing here.
    }

    public override bool IsComplete()
    {
        // Eternal goals are never completed, so we always return false.
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetDetailsString()}";
    }
}