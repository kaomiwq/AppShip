using System;
using System.Collections.Generic;

namespace AppShip.Models;

public partial class Ship
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CaptainId { get; set; }

    public string Status { get; set; } = null!;

    public string Price { get; set; } = null!;

    public virtual Captain Captain { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
