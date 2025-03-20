namespace Lab4;

public class Minute
{
    private int _minute;

    public Minute(int value)
    {
        Value = value;
    }

    public int Value
    {
        get => _minute;
        set
        {
            if (value < 0 || value > 59)
                _minute = 0;
            else
                _minute = value;
        }
    }

    public override string ToString()
    {
        return Value.ToString("D2");
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Minute)
            return false;

        var other = (Minute)obj;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}

public class Time
{
    private int _hour;

    public Time(int hour, Minute minute)
    {
        Minute = minute;
        Hour = hour;
    }

    public Minute Minute { get; set; }

    public int Hour
    {
        get => _hour;
        set
        {
            if (value < 0 || value > 23)
                _hour = 0;
            else
                _hour = value;
        }
    }

    public override string ToString()
    {
        return $"{Hour:D2}:{Minute}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Time)
            return false;

        var other = (Time)obj;
        return Hour == other.Hour && Minute.Equals(other.Minute);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hour, Minute);
    }
}

public class Day
{
    public Day(Time current_time)
    {
        Time = current_time;
    }

    public Time Time { get; set; }

    public void WriteCurrentTime()
    {
        Console.WriteLine($"Поточний час: {Time}");
    }

    public string CalculateDayTime()
    {
        var hour = Time.Hour;

        return hour switch
        {
            < 12 and >= 5 => "Ранок",
            < 17 and >= 12 => "День",
            < 22 and >= 17 => "Вечір",
            _ => "Ніч"
        };
    }

    public override string ToString()
    {
        return $"Доба [поточний час: {Time}, час доби: {CalculateDayTime()}]";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Day)
            return false;

        var other = (Day)obj;
        return Time.Equals(other.Time);
    }

    public override int GetHashCode()
    {
        return Time.GetHashCode();
    }
}