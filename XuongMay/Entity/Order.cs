using System;
using System.Collections.Generic;

namespace XuongMay.Entity;

public partial class Order
{
    public Guid IdOrder { get; set; }

    public int? Status { get; set; }

    public decimal Total { get; set; }

    public DateTime CreateAt { get; set; }

    public Guid? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
