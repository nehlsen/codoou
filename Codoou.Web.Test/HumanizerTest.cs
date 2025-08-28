using Codoou.Web.HumanizedDuration;

namespace Codoou.Web.Test;

[TestFixture]
[TestOf(typeof(Humanizer))]
public class HumanizerTest
{
    private readonly Humanizer _humanizer = new();

    [Test]
    public void Humanize_zero_seconds()
    {
        DateTime target = DateTime.Parse("2024-06-01 12:00:00");
        DateTime current = DateTime.Parse("2024-06-01 12:00:00");

        var timeSpan = _humanizer.Humanize(target, current);
        Assert.That(timeSpan.Years, Is.EqualTo(0));
        Assert.That(timeSpan.Months, Is.EqualTo(0));
        Assert.That(timeSpan.Weeks, Is.EqualTo(0));
        Assert.That(timeSpan.Remainder, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void Humanize_four_days()
    {
        DateTime target = DateTime.Parse("2024-06-01 12:00:00");
        DateTime current = DateTime.Parse("2024-06-05 12:00:00");

        var timeSpan = _humanizer.Humanize(target, current);
        Assert.That(timeSpan.Years, Is.EqualTo(0));
        Assert.That(timeSpan.Months, Is.EqualTo(0));
        Assert.That(timeSpan.Weeks, Is.EqualTo(0));
        Assert.That(timeSpan.Remainder, Is.EqualTo(TimeSpan.FromDays(4)));
    }

    [Test]
    public void Humanize_one_week_and_two_days()
    {
        DateTime target = DateTime.Parse("2024-06-01 12:00:00");
        DateTime current = DateTime.Parse("2024-06-10 12:00:00");

        var timeSpan = _humanizer.Humanize(target, current);
        Assert.That(timeSpan.Years, Is.EqualTo(0));
        Assert.That(timeSpan.Months, Is.EqualTo(0));
        Assert.That(timeSpan.Weeks, Is.EqualTo(1));
        Assert.That(timeSpan.Remainder, Is.EqualTo(TimeSpan.FromDays(2)));
    }

    [Test]
    public void Humanize_one_month_and_two_days()
    {
        DateTime target = DateTime.Parse("2024-06-01 12:00:00");
        DateTime current = DateTime.Parse("2024-07-03 12:00:00");

        var timeSpan = _humanizer.Humanize(target, current);
        Assert.That(timeSpan.Years, Is.EqualTo(0));
        Assert.That(timeSpan.Months, Is.EqualTo(1));
        Assert.That(timeSpan.Weeks, Is.EqualTo(0));
        Assert.That(timeSpan.Remainder, Is.EqualTo(TimeSpan.FromDays(2)));
    }

    [Test]
    public void Humanize_one_year_and_two_days()
    {
        DateTime target = DateTime.Parse("2024-06-01 12:00:00");
        DateTime current = DateTime.Parse("2025-06-03 12:00:00");

        var timeSpan = _humanizer.Humanize(target, current);
        Assert.That(timeSpan.Years, Is.EqualTo(1));
        Assert.That(timeSpan.Months, Is.EqualTo(0));
        Assert.That(timeSpan.Weeks, Is.EqualTo(0));
        Assert.That(timeSpan.Remainder, Is.EqualTo(TimeSpan.FromDays(2)));
    }

    [Test]
    public void Humanize_one_of_each()
    {
        DateTime target = DateTime.Parse("2024-06-01 12:00:00");
        DateTime current = DateTime.Parse("2025-07-09 13:01:01");

        var timeSpan = _humanizer.Humanize(target, current);
        Assert.That(timeSpan.Years, Is.EqualTo(1));
        Assert.That(timeSpan.Months, Is.EqualTo(1));
        Assert.That(timeSpan.Weeks, Is.EqualTo(1));
        Assert.That(timeSpan.Remainder, Is.EqualTo(new TimeSpan(1, 1, 1, 1)));
    }
}
