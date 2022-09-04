namespace GL.NET.Entities;

public class AllianceUser
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Avatar { get; set; }

    public AllianceRole AllianceRole { get; set; }

    public int TotalWarPoints { get; set; }
}
