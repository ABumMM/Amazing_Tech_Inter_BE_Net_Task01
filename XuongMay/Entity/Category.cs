using System;
using System.Collections.Generic;

namespace XuongMay.Entity;

public partial class Category
{
    public Guid IdCategory { get; set; }

    public string? Slug { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
