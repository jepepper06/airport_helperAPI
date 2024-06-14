using System.Text.Json.Serialization;

namespace AirpotControllerHelperAPI.Model;

public class Airplane
{
    public long Id { get; set; }
    public string Owner { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime? TimeToArriveOnAirport { get; set; } = null;
    public void AssingTimeToArriveAtAirport(DateTime timeToArrive)
    {
        TimeToArriveOnAirport = timeToArrive;
    }
}
