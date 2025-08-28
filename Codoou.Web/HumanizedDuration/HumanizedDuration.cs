namespace Codoou.Web.HumanizedDuration;

public class HumanizedDuration
{
    public int Years { get; init; }
    public int Months { get; init; }
    public int Weeks { get; init; }
    public int Days => Remainder.Days;
    public int Hours => Remainder.Hours;
    public int Minutes => Remainder.Minutes;
    public int Seconds => Remainder.Seconds;
    public TimeSpan Remainder { get; init; } = TimeSpan.Zero;
}
