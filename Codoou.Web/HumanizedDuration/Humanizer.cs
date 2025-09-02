namespace Codoou.Web.HumanizedDuration;

public class Humanizer
{
    public HumanizedDuration Humanize(DateTime target, DateTime? current = null)
    {
        current ??= DateTime.Now;

        return target < current.Value ? CalculateHumanizedDuration(target, current.Value) : CalculateHumanizedDuration(current.Value, target);
    }

    private HumanizedDuration CalculateHumanizedDuration(DateTime from, DateTime to)
    {
        if (from > to)
        {
            throw new ArgumentException("from must be earlier than to");
        }

        var years = to.Year - from.Year;
        var months = to.Month - from.Month;
        if (to.Month > from.Month && to.Day < from.Day)
        {
            months -= 1;
        }
        var remainder = to - from.AddYears(years).AddMonths(months);

        var weeks = 0;
        if (remainder.Days > 6)
        {
            weeks = remainder.Days / 7;
            remainder = remainder.Subtract(TimeSpan.FromDays(weeks * 7));
        }

        return new HumanizedDuration
        {
            Years = years,
            Months = months,
            Weeks = weeks,
            Remainder = remainder
        };
    }
}
