using AirpotControllerHelperAPI.Model;

public class ControlTower
{
    public ICollection<AirportRunway> AirportRunways { get; set; } = new List<AirportRunway>();
    public ICollection<Airplane> AirplanesWaiting { get; set; } = new List<Airplane>();
    public void AddAirplaneToAirportRunway(AirportRunway airportRunway, Airplane airplane, DateTime timeToArrive)
    {
        airplane.AssingTimeToArriveAtAirport(timeToArrive);
        AirplanesWaiting.Remove(airplane);
        airportRunway.AirplanesAssined.Add(airplane);
    }
    public void RemoveAirplaneFromAirportRunway(AirportRunway airportRunway, Airplane airplane)
    {
        airportRunway.AirplanesAssined.Remove(airplane);
    }


