namespace GL.NET.Entities;

public class Login
{
    public ulong CommandsSinceLastLogin { get; set; }

    public DateTime Time { get; set; }
}
