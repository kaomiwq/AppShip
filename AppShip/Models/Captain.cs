using System;
using System.Collections.Generic;

namespace AppShip.Models;

public partial class Captain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Rating { get; set; }

    public virtual ICollection<Ship> Ships { get; set; } = new List<Ship>();
}
