using AirpotControllerHelperAPI.Model;

public class AirportRunway
{   
    public int Id { get; set; }
    public ICollection<Airplane> AirplanesAssined { get; set; } = new List<Airplane>();
}

