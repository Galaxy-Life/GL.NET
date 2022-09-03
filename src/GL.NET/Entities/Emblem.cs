namespace GL.NET.Entities;

public class Emblem
{
    public Emblem(string emblemInTextForm)
    {
        /* Convert GL's emblem in text form to the class */
        var parts = emblemInTextForm.Split(',');

        Shape = (EmblemShape)int.Parse(parts[0]);
        Pattern = (EmblemPattern)int.Parse(parts[1]);
        Icon = (EmblemIcon)int.Parse(parts[2]);
    }

    public EmblemShape Shape { get; set; }
    public EmblemPattern Pattern { get; set; }
    public EmblemIcon Icon { get; set; }

    public override string ToString()
        => $"{(int)Shape},{(int)Pattern},{(int)Icon},";
}

public enum EmblemShape
{
    Circle = 0,
    Diamond = 1,
    Badge = 2,
    Cross = 3,
    Shield = 4
}

public enum EmblemPattern
{
    CrackedBlue = 0,
    CrackedRed = 1,
    CrackedGreen = 2,
    CrackedBlack = 3,
    CrackedPink = 4,
    Blue = 5,
    Red = 6,
    Green = 7,
    Black = 8,
    Pink = 9,
    DualBlue = 10,
    DualRed = 11,
    DualGreen = 12,
    DualBlack = 13,
    DualPink = 14
}

public enum EmblemIcon
{
    Rabbit = 0,
    Skull = 1,
    Viking = 2,
    Octopus = 3,
    Devil = 4,
    Angel = 5,
    Gladiator = 6,
    NativeAmerican = 7,
    Soldier = 8,
    Pilot = 9,
    Starlinator = 10,
    Fists = 11,
    Ufo = 12,
    Gun = 13,
    Orange = 14
}
