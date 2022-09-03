using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.NET.Entities;

public class AllianceDto
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Emblem Emblem { get; set; }

    public int AllianceLevel { get; set; }

    public int KnockoutPoints { get; set; }

    public AllianceUser[] Members { get; set; }
}
