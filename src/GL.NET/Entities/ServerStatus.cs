namespace GL.NET.Entities;

public class ServerStatus
{
    public ServerStatus(string name, bool isOnline, int ping)
    {
        Name = name;
        IsOnline = isOnline;
        Ping = ping;
    }

    public string Name { get; set; }

    public bool IsOnline { get; set; }

    public int Ping { get; set; }
}
