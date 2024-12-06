using System;
using System.Collections.Generic;

namespace AppShip.Models;

public partial class Order
{
    public int Id { get; set; }

    public int StaffId { get; set; }

    public int ClientId { get; set; }

    public int ShipId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Ship Ship { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
