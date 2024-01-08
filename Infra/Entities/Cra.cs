namespace Infra.Entities;

public class Cra
{
    public int Id { get; set; }
    public DateTime Month { get; set; }
    public Dictionary<int, int> Days { get; set; }
    public int Total => Days.Sum(x => x.Value);

    public Status Status { get; set; }

    //init Days with all days uin the month
    public Cra(DateTime month)
    {
        Month = new DateTime(month.Year, month.Month, 1);
        Days = Enumerable.Range(1, DateTime.DaysInMonth(month.Year, month.Month))
            .ToDictionary(m => m, m => 0);

        var weDays = Days.Where(x =>
        {
            var date = new DateTime(month.Year, month.Month, x.Key);
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        })
        .ToList();

        //remove weekends
        foreach (var day in weDays)
        {
            Days.Remove(day.Key);
        }

        Status = Status.Draft;


    }
}
public enum Status
{
    Draft,
    Submitted,
    Approved,
    Rejected
}