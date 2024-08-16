using System;
using System.Collections.Generic;

namespace XuongMay.Entity;

public partial class Role
{
    public Guid IdRole { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
