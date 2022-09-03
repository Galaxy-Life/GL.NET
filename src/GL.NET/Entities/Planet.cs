namespace GL.NET.Entities;

public class Planet
{
    public string OwnerId { get; set; }

    public int PlanetId { get; set; }

    public string StarId { get; set; }

    public int StarPos { get; set; }

    public int HQLevel { get; set; }

    public long CoinsLimit { get; set; }

    public long MineralsLimit { get; set; }

    public int PercentageDestroyed { get; set; }
}
