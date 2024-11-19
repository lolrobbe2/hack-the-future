namespace Involved.HTF.Common.Dto;

public class ZyphoraTheWaitingWorldDto
{
    /// <summary>
    ///     Time on the planet
    /// </summary>
    public DateTime SendDateTime { get; set; }

    /// <summary>
    ///     The speed at which the message travels in lightYears/minute
    /// </summary>
    public int TravelSpeed { get; set; }

    /// <summary>
    ///     The distance between the planet and the base station in light years
    /// </summary>
    public int Distance { get; set; }

    /// <summary>
    ///     The nr of hours in a day on the planet
    /// </summary>
    public int DayLength { get; set; }
    public int DistanceCalc { get => Distance * 2; }

    public int getDaylengthMinutes()
    {
        return DayLength * 60;
    }
    public float getDurationMin()
    {
        return DistanceCalc / TravelSpeed;
    }
    public int getDays()
    {
        return (int)(getDurationMin() / getDaylengthMinutes());
    }
    public float remainingMinutes()
    {
        return getDurationMin() - (getDays() * getDaylengthMinutes());
    }
    public int getHours() 
    {
        return (int)(remainingMinutes() / 60); ;
    }
    public float getMinutes() 
    {
        return remainingMinutes() % 60;
    }
    public string getArrival() 
    {
        DateTime arrival = SendDateTime;
        Console.WriteLine(getDays());
        Console.WriteLine(getHours());
        Console.WriteLine(getMinutes());
        arrival.AddDays(getDays());  
        arrival.AddHours(getHours());
        return arrival.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}