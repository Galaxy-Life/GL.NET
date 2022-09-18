namespace GL.NET.Entities;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Avatar { get; set; }

    public bool Online { get; set; }

    public long Level { get; set; }

    public long Experience { get; set; }

    public string AllianceId { get; set; }

    public Planet[] Planets { get; set; }
}
